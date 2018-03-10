using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Schedule.IntIta.Domain.Models;
using Schedule.IntIta.ViewModels;
using Schedule.IntIta.DataAccess;
using Schedule.IntIta.BusinessLogic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;

namespace Schedule.IntIta.Controllers
{
    public class TimeSlotController : Controller
    {
        private readonly IMapper _mapper;
        public TimeSlotController(IMapper mapper)
        {
            _mapper = mapper;

        }
        // GET: TimeSlot
        public ActionResult Index()
        {
            TimeSlotRepository tsRepo = new TimeSlotRepository();
            return View(tsRepo.GetAll());
            
        }

        [HttpGet]
        public ActionResult Create()
            
        {
             TimeSlotTypesRepository tsRepo = new TimeSlotTypesRepository();
             var items = tsRepo.GetAll().Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Type }).ToList();
             ViewBag.Types = new SelectList(items, "Id", "Type");
            //TimeSlotViewModel tsModel = new TimeSlotViewModel() { Statuses = items }; 
            // return View(tsModel);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // GET: TimeSlot/Create
        //public ActionResult Create(DateTime StartTime, DateTime EndTime, string IdType)
        //{
        //    using (var stream = new System.IO.MemoryStream())
        //    {
        //        Request.Body.CopyTo(stream);
        //        stream.Position = 0;
        //        var bytes = new byte[(int)Request.ContentLength];
        //        stream.Read(bytes, 0, bytes.Length);
        //        var text = Encoding.Default.GetString(bytes);
        //    }

        //        TimeSlot timeSlot = new TimeSlot();
        //    //timeSlot.IdType = id;
        //    return RedirectToAction("Index");

        //}
        public ActionResult Create(TimeSlotViewModel tsModel)
        {
            int SelectValue = tsModel.IdType;
            ViewBag.SelectedValue = tsModel.IdType;
            // TimeSlotTypeViewModel tstModel = new TimeSlotTypeViewModel();
            //TimeSlotTypesRepository tstRepo = new TimeSlotTypesRepository();
            TimeSlot tSlot = Mapper.Map<TimeSlotViewModel, TimeSlot>(tsModel);
           
            // TimeSlotTypes tTSLot = Mapper.Map<TimeSlotTypeViewModel, TimeSlotTypes>(tstModel);
            try
            {
                Console.WriteLine("Something happened");
                List<TimeSlotViewModel> listTimeSlotViewModel = new List<TimeSlotViewModel>();   
                TimeSlotRepository tsRepo = new TimeSlotRepository();
                TimeSlotBuisnessLogic tsBLogic = new TimeSlotBuisnessLogic(tsRepo);
                ///   tSlot.IdType = tTSLot.Id;
                tsBLogic.Add(tSlot);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }

        }

        // GET: TimeSlot/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                TimeSlotRepository tsRepo = new TimeSlotRepository();
                TimeSlotBuisnessLogic tsBLogic = new TimeSlotBuisnessLogic(tsRepo);
                TimeSlotViewModel tsModel = Mapper.Map<TimeSlot, TimeSlotViewModel>(tsBLogic.Read(id));
                return View(tsModel);
            }
            catch
            {
                return View();
            }
        }

        // POST: TimeSlot/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TimeSlotViewModel tsModel)
        {
            TimeSlot tSlot = Mapper.Map<TimeSlotViewModel, TimeSlot>(tsModel);
            try
            {
                TimeSlotRepository tsRepo = new TimeSlotRepository();
                TimeSlotBuisnessLogic tsBLogic = new TimeSlotBuisnessLogic(tsRepo);
                tsBLogic.Update(tSlot);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: TimeSlot/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                TimeSlotRepository tsRepo = new TimeSlotRepository();
                TimeSlotBuisnessLogic tsBLogic = new TimeSlotBuisnessLogic(tsRepo);
                TimeSlotViewModel tsModel = Mapper.Map<TimeSlot, TimeSlotViewModel>(tsBLogic.Read(id));
                return View(tsModel);
            }
            catch
            {
                return View();
            }
        }

        // POST: TimeSlot/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                TimeSlotRepository tsRepo = new TimeSlotRepository();
                TimeSlotBuisnessLogic tsBLogic = new TimeSlotBuisnessLogic(tsRepo);
                tsBLogic.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}