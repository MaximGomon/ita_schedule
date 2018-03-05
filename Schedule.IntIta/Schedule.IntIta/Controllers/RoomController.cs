﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Schedule.IntIta.Domain.Models;
using Schedule.IntIta.Domain.Models.Enumerations;
using AutoMapper;
using Schedule.IntIta.BusinessLogic;
using Schedule.IntIta.DataAccess;
using Schedule.IntIta.ViewModels;

namespace Schedule.IntIta.Controllers
{
    public class RoomController : Controller
    {

        private readonly IMapper _mapper;

        public RoomController(IMapper mapper)
        {
            _mapper = mapper;
        }

        // GET: Room
        public ActionResult Test()
        {
            return View();
        }

        public ActionResult Index()
        {
            RoomRepository roomsR = new RoomRepository();
            
            return View(roomsR.GetAll().Select(x =>
                Mapper.Map<Room, RoomViewModel>(x)));
        }

        // GET: Room/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Room/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

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

            return View();
        }

        // POST: Room/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

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
                RoomRepository roomR = new RoomRepository();
                RoomBusinessLogic roomBL = new RoomBusinessLogic(roomR);
                RoomViewModel room = Mapper.Map<Room, RoomViewModel>(roomBL.Get(id));
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
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}