using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Schedule.IntIta.BusinessLogic;
using Schedule.IntIta.DataAccess;
using Schedule.IntIta.DataAccess.Context;
using Schedule.IntIta.Domain.Models;
using Schedule.IntIta.ViewModels;

namespace Schedule.IntIta.Controllers
{
    public class EventController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IntitaDbContext _db = new IntitaDbContext();

        public EventController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            EventBusinessLogic eventBusinessLogic = new EventBusinessLogic(new EventRepository());
            var events = eventBusinessLogic.GetAll();
            List<EventViewModel> model = new List<EventViewModel>();

            foreach (var item in events)
            {
                model.Add(_mapper.Map<EventViewModel>(item));
            }

            return View(model);
        }

        // GET: Room/Create
        public ActionResult Create()
        {
            //TODO: перенести все в репозиторий
            SelectList eventTypes = new SelectList(_db.EventTypes, "Id", "Name");
            SelectList timeSlotTypes = new SelectList(_db.TimeSlotTypes, "Id", "Type");
            ViewData["eventTypes"] = eventTypes;
            ViewData["timeSlotTypes"] = timeSlotTypes;

            return View();
        }

        // POST: Room/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventViewModel eventViewModel)
        {
            try
            {
                var item = _mapper.Map<Event>(eventViewModel);
                EventBusinessLogic eventBusinessLogic = new EventBusinessLogic(new EventRepository());
                eventBusinessLogic.Add(item);

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
            EventBusinessLogic eventBusinessLogic = new EventBusinessLogic(new EventRepository());
            var model = _mapper.Map<EventViewModel>(eventBusinessLogic.Read(id));
            return View(model);
        }

        // POST: Room/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EventViewModel postEvent)
        {
            try
            {
                EventBusinessLogic eventBusinessLogic = new EventBusinessLogic(new EventRepository());
                eventBusinessLogic.Update(_mapper.Map<Event>(postEvent));

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
        public ActionResult Delete(int id, EventViewModel deleteEvent)
        {
            try
            {
                EventBusinessLogic eventBusinessLogic = new EventBusinessLogic(new EventRepository());
                eventBusinessLogic.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}