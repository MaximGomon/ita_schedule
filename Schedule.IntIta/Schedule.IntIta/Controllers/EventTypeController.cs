using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Schedule.IntIta.BusinessLogic;
using Schedule.IntIta.DataAccess.Context;
using Schedule.IntIta.Domain.Models;
using Schedule.IntIta.ViewModels;

namespace Schedule.IntIta.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EventTypeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IntitaDbContext _context;
        private readonly IEventTypeBusinessLogic _eventTypeBusinessLogic;

        public EventTypeController(IMapper mapper, IEventTypeBusinessLogic eventTypeBusinessLogic, IntitaDbContext context)
        {
            _mapper = mapper;
            _eventTypeBusinessLogic = eventTypeBusinessLogic;
            _context = context;
        }

        public ActionResult Index()
        {
            var eventTypes = _eventTypeBusinessLogic.GetAll();
            List<EventTypeViewModel> model = new List<EventTypeViewModel>();

            foreach (var item in eventTypes)
            {
                model.Add(_mapper.Map<EventTypeViewModel>(item));
            }
            
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
        public ActionResult Create(EventTypeViewModel eventTypeViewModel)
        {
            try
            {
                _eventTypeBusinessLogic.Add(_mapper.Map<EventType>(eventTypeViewModel));
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
            var model = _mapper.Map<EventTypeViewModel>(_eventTypeBusinessLogic.Read(id));
            return View(model);
        }

        // POST: Room/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EventTypeViewModel postEventType)
        {
            try
            {
                _eventTypeBusinessLogic.Update(_mapper.Map<EventType>(postEventType));
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
            var model = _mapper.Map<EventTypeViewModel>(_eventTypeBusinessLogic.Read(id));
            return View(model);
        }

        // POST: Room/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, EventTypeViewModel deleteEventType)
        {
            try
            {
                _eventTypeBusinessLogic.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}