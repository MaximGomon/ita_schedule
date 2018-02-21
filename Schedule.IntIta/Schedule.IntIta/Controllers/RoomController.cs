using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Schedule.IntIta.Domain.Models;
using Schedule.IntIta.Domain.Models.Enumerations;
using AutoMapper;
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
            Room room1 = new Room
            {
                Id = 1,
                IsDeleted = false,
                Name = "Sea Room",
                SeatNumber = 30,
                RoomStatus = RoomStatus.Active
            };
            Room room2 = new Room
            {
                Id = 2,
                IsDeleted = false,
                Name = "Magenta Room",
                SeatNumber = 20,
                RoomStatus = RoomStatus.Active
            };
            Room room3 = new Room
            {
                Id = 3,
                IsDeleted = false,
                Name = "Relax Room",
                SeatNumber = 10,
                RoomStatus = RoomStatus.Active
            };
            Room room4 = new Room
            {
                Id = 4,
                IsDeleted = false,
                Name = "Square space",
                SeatNumber = 30,
                RoomStatus = RoomStatus.Active
            };
            Room room5 = new Room
            {
                Id = 5,
                IsDeleted = false,
                Name = "Long space",
                SeatNumber = 40,
                RoomStatus = RoomStatus.Active
            };


            List<Room> model = new List<Room> { room1, room2, room3, room4, room5 };

            return View(model);
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
            return View();
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