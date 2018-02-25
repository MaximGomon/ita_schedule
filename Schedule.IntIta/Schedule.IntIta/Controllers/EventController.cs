using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Schedule.IntIta.Domain.Models;
using Schedule.IntIta.Domain.Models.Enumerations;

namespace Schedule.IntIta.Controllers
{
    public class EventController : Controller
    {
        private readonly IMapper _mapper;

        public EventController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            List<Event> model = new List<Event>();
            TimeSlot ts = new TimeSlot
            {
                StartTime = DateTime.Now,
                EndTime = DateTime.MaxValue
            };
            EventType et = new EventType {Name = "Lesson"};

            Event event1 = new Event()
            {
                Comments = "comment",
                Id = 1,
                Date = ts,
                TypeOfEvent = et,
                GroupId = 1,
                InitiatorId = 1,
                RoomId = 1,
                SubjectId = 1
            };
            model.Add(event1);

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