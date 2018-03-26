﻿using System;
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
using Schedule.IntIta.Domain.Models.Enumerations;
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
            return View(model);
        }

        // GET: Room/Create
        [HttpGet]
        public ActionResult Create()
        {
            OfficeRepository officeRepository = new OfficeRepository();
            var items = officeRepository.GetAll()
                .Select(x => new SelectListItem {Value = x.Id.ToString(), Text = x.Name}).ToList();
            RoomViewModel roomModel = new RoomViewModel() {Offices = new SelectList(items, "Value", "Text")};
            return View(roomModel);
        }

        // POST: Room/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RoomViewModel officeModel)
        {
            Room room = Mapper.Map<RoomViewModel, Room>(officeModel);

            try
            {
                room.RoomStatus = RoomStatus.Active;
                _roomBusinessLogic.Add(_mapper.Map<Room>(room));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Room/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    OfficeRepository officeR = new OfficeRepository();
        //    ViewBag.Office = new SelectList(officeR.GetAll(), "Id", "Name");

        //    return View(Mapper.Map<Room, RoomViewModel>(_roomRepository.Get(id)));
        //}
        public ActionResult Edit(int id)
        {
            try
            {
                OfficeRepository OffRepo = new OfficeRepository();
                var items = OffRepo.GetAll().Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).ToList();
                RoomViewModel roomModel = Mapper.Map<Room, RoomViewModel>(_roomBusinessLogic.Read(id));
                roomModel.Offices = new SelectList(items, "Value", "Text");
                
                return View(roomModel);
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RoomViewModel Model)
        {
            Room room = Mapper.Map<RoomViewModel, Room>(Model);
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
                OfficeRepository OffRepo = new OfficeRepository();
                var items = OffRepo.GetAll().Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).ToList();
                RoomViewModel roomModel = Mapper.Map<Room, RoomViewModel>(_roomBusinessLogic.Read(id));
                roomModel.Offices = new SelectList(items, "Value", "Text");
                return View(roomModel);
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