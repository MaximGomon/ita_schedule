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
    [Authorize]
    public class EventController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IntitaDbContext _db = new IntitaDbContext();
        private readonly IEventBusinessLogic _eventBusinessLogic;

        public EventController(IMapper mapper, IEventBusinessLogic eventBusinessLogic)
        {
            _mapper = mapper;
            _eventBusinessLogic = eventBusinessLogic;
        }

        public ActionResult Index()
        {
            var events = _eventBusinessLogic.GetAll();
            
            List<EventViewModel> model = new List<EventViewModel>();

            foreach (var item in events)
            {
                model.Add(_mapper.Map<EventViewModel>(item));
            }

            //TODO перенести в репозиторий
            ViewBag.Subject = _db.Subjects.ToList();
            ViewBag.User = _db.Users.ToList();
            ViewBag.Room = _db.Rooms.ToList();
            ViewBag.Group = _db.Groups.ToList();

            return View(model);
        }

        // GET: Room/Create
        public ActionResult Create()
        {
            //TODO: перенести все в репозиторий
            SelectList eventTypes = new SelectList(_db.EventTypes, "Id", "Name");
            SelectList timeSlotTypes = new SelectList(_db.TimeSlotTypes, "Id", "Type");
            SelectList userSelectList = new SelectList(_db.Users, "Id", "LastName");
            SelectList roomSelectList = new SelectList(_db.Rooms, "Id", "Name");
            SelectList groupSelectList = new SelectList(_db.Groups, "Id", "Name");
            SelectList subjectSelectList = new SelectList(_db.Subjects, "Id", "Name");

            ViewData["eventTypes"] = eventTypes;
            ViewData["timeSlotTypes"] = timeSlotTypes;
            ViewData["subjectSelectList"] = subjectSelectList;
            ViewData["userSelectList"] = userSelectList;
            ViewData["roomSelectList"] = roomSelectList;
            ViewData["groupSelectList"] = groupSelectList;
            
            return View();
        }

        // POST: Room/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventViewModel eventViewModel)
        {
            try
            {
                _eventBusinessLogic.Add(_mapper.Map<Event>(eventViewModel));
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
            SelectList eventTypes = new SelectList(_db.EventTypes, "Id", "Name");
            SelectList timeSlotTypes = new SelectList(_db.TimeSlotTypes, "Id", "Type");
            SelectList userSelectList = new SelectList(_db.Users, "Id", "LastName");
            SelectList roomSelectList = new SelectList(_db.Rooms, "Id", "Name");
            SelectList groupSelectList = new SelectList(_db.Groups, "Id", "Name");
            SelectList subjectSelectList = new SelectList(_db.Subjects, "Id", "Name");

            ViewData["eventTypes"] = eventTypes;
            ViewData["timeSlotTypes"] = timeSlotTypes;
            ViewData["subjectSelectList"] = subjectSelectList;
            ViewData["userSelectList"] = userSelectList;
            ViewData["roomSelectList"] = roomSelectList;
            ViewData["groupSelectList"] = groupSelectList;

            var model = _mapper.Map<EventViewModel>(_eventBusinessLogic.Read(id));
            return View(model);
        }

        // POST: Room/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EventViewModel postEvent)
        {
            try
            {
                _eventBusinessLogic.Update(_mapper.Map<Event>(postEvent));
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
            var model = _mapper.Map<EventViewModel>(_eventBusinessLogic.Read(id));
            return View(model);
        }

        // POST: Room/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, EventViewModel deleteEvent)
        {
            try
            {
                _eventBusinessLogic.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public JsonResult GetEvents()
        {
            var events = _eventBusinessLogic.GetAll();
            List<CalendarEventViewModel> list = new List<CalendarEventViewModel>();

            foreach (var item in events)
            {
                var calendarEvent = _mapper.Map<CalendarEventViewModel>(item);
                calendarEvent.Group = _db.Groups.Single(x => x.Id == item.GroupId);
                calendarEvent.Initiator = _db.Users.Single(x => x.Id == item.InitiatorId);
                calendarEvent.Room = _db.Rooms.Single(x => x.Id == item.RoomId);
                calendarEvent.Subject = _db.Subjects.Single(x => x.Id == item.SubjectId);
                list.Add(calendarEvent);
            }


            return new JsonResult(list);
        }
    }
}