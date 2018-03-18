using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Schedule.IntIta.Domain.Models;
using Schedule.IntIta.ViewModels;
using Schedule.IntIta.BusinessLogic;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Schedule.IntIta.Controllers
{
    public class TimeSlotController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITimeSlotBuisnessLogic _timeSlotBusinessLogic;
        public TimeSlotController(IMapper mapper,           
            ITimeSlotBuisnessLogic timeSlotBuisnessLogic)
        {
            _mapper = mapper;
            _timeSlotBusinessLogic = timeSlotBuisnessLogic;
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View(_timeSlotBusinessLogic.GetAllTimeSlots().ToList());
        }
        [HttpGet]
        public ActionResult Create()

        {

            var items = _timeSlotBusinessLogic.GetAllTimeSlotTypes()
                .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Type })
                .ToList();
            TimeSlotViewModel tsModel = new TimeSlotViewModel() { Types = new SelectList(items, "Value", "Text") };
            return View(tsModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TimeSlotViewModel tsModel)
        {
            try
            {
                Console.WriteLine("Something happened");
                _timeSlotBusinessLogic.Add(_mapper.Map<TimeSlotViewModel, TimeSlot>(tsModel));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                var items = _timeSlotBusinessLogic.GetAllTimeSlotTypes().Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Type }).ToList();
                TimeSlotViewModel tsModel = _mapper.Map<TimeSlot, TimeSlotViewModel>(_timeSlotBusinessLogic.Read(id));
                tsModel.Types = new SelectList(items, "Value", "Text");

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
            try
            {
                _timeSlotBusinessLogic.Update(_mapper.Map<TimeSlotViewModel, TimeSlot>(tsModel));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
         // GET: TimeSlot/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                TimeSlotViewModel tsModel = _mapper.Map<TimeSlot, TimeSlotViewModel>(_timeSlotBusinessLogic.Read(id));
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
                _timeSlotBusinessLogic.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}