using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Schedule.IntIta.BusinessLogic;
using Schedule.IntIta.DataAccess;
using Schedule.IntIta.Domain.Models;
using Schedule.IntIta.Domain.Models.Enumerations;
using Schedule.IntIta.ViewModels;

namespace Schedule.IntIta.Controllers
{
    public class RoomController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRoomBusinessLogic _roomBusinessLogic;
        private readonly IRoomRepository _roomRepository;

        public RoomController(IMapper mapper, IRoomBusinessLogic roomBusinessLogic, IRoomRepository roomRepository)
        {
            _mapper = mapper;
            _roomBusinessLogic = roomBusinessLogic;
            _roomRepository = roomRepository;
        }
        /*
        public ActionResult Index()
        {
            RoomBusinessLogic roomBusinessLogic = new RoomBusinessLogic(new RoomRepository());
            var rooms = roomBusinessLogic.GetAll();
            List<RoomViewModel> model = new List<RoomViewModel>();

            foreach (var item in rooms)
            {
                model.Add(_mapper.Map<RoomViewModel>(item));
            }

            return View(model);
            
        }*/

        // GET: Room
        //public ActionResult Test()
        //{
        //    return View();
        //}

        public ActionResult Index()
        {
            return View(_roomRepository.GetAll().Select(x =>
                Mapper.Map<Room, RoomViewModel>(x)));
        }

        // GET: Room/Create
        public ActionResult Create()
        {
            ViewBag.Office = new SelectList(_roomRepository.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Room/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RoomViewModel model)
        {
            Room room = Mapper.Map<RoomViewModel, Room>(model);
            try
            {
                room.RoomStatus = RoomStatus.Active;
                _roomBusinessLogic.Add(room);
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