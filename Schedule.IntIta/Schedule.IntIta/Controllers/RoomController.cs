using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Schedule.IntIta.BusinessLogic;
using Schedule.IntIta.DataAccess;
using Schedule.IntIta.DataAccess.Context;
using Schedule.IntIta.Domain.Models;
using Schedule.IntIta.ViewModels;

namespace Schedule.IntIta.Controllers
{
    public class RoomController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRoomBusinessLogic _roomBusinessLogic;
        private readonly IRoomRepository _roomRepository;
        private readonly IntitaDbContext _db = new IntitaDbContext();

        public RoomController(IMapper mapper, IRoomBusinessLogic roomBusinessLogic, IRoomRepository roomRepository)
        {
            _mapper = mapper;
            _roomBusinessLogic = roomBusinessLogic;
            _roomRepository = roomRepository;
        }
        
        // GET: Room
        //public ActionResult Test()
        //{
        //    return View();
        //}

        public ActionResult Index()
        {
            var rooms = _roomRepository.GetAll();

            List<RoomViewModel> model = new List<RoomViewModel>();

            foreach (var item in rooms)
            {
                model.Add(_mapper.Map<RoomViewModel>(item));
            }
            ViewBag.Office = _db.Office.ToList();
            return View(model);
        }

        // GET: Room/Create
        public ActionResult Create()
        {
            SelectList officesList = new SelectList(_db.Office, "Id", "Name");

            ViewData["officesList"] = officesList;
            return View();
        }

        // POST: Room/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RoomViewModel model)
        {
            try
            {
                _roomBusinessLogic.Add(_mapper.Map<Room>(model));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Room/Edit/5
        public ActionResult Edit(int id)
        {
            OfficeRepository officeR = new OfficeRepository();
            ViewBag.Office = new SelectList(officeR.GetAll(), "Id", "Name");

            return View(Mapper.Map<Room, RoomViewModel>(_roomRepository.Get(id)));
        }

        // POST: Room/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RoomViewModel model)
        {
            Room room = Mapper.Map<RoomViewModel, Room>(model);
            try
            {
                _roomBusinessLogic.Update(room);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Room/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                RoomViewModel room = Mapper.Map<Room, RoomViewModel>(_roomBusinessLogic.Read(id));
                return View(room);
            }
            catch
            {
                return View();
            }
        }

        // POST: Room/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _roomBusinessLogic.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}