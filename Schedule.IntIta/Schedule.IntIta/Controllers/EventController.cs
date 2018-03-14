using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Schedule.IntIta.BusinessLogic;
using Schedule.IntIta.DataAccess.Context;
using Schedule.IntIta.Domain.Models;
using Schedule.IntIta.ViewModels;

namespace Schedule.IntIta.Controllers
{
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

        public async Task<IActionResult> Index(string sortOrder, string sType, string sGroup, string sInitiator, string sRoom)
        //public ActionResult Index(string sortOrder)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "type_desc" : "";
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "initiator_desc" : "";
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "room_desc" : "";
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "group_desc" : "";
            ViewData["TypeFilter"] = sType;
            ViewData["GroupFilter"] = sGroup;
            ViewData["RoomFilter"] = sRoom;
            ViewData["InitiatorFilter"] = sInitiator;


            var events = _eventBusinessLogic.GetAll();

            if (!String.IsNullOrEmpty(sType))
            {
                //events = events.Where(s => s.Comments.Contains(sType));
                events = events.Where(s => s.TypeOfEvent.Name.Contains(sType));
            }
            if (!String.IsNullOrEmpty(sGroup))
            {
                var group = _db.Groups.ToList().Where(x => x.Name.Contains(sGroup)).Select(x => (int?)x.Id);
                //events = events.Where(x => group.Contains(x.GroupId)).ToList();
                events = events.Where(x => x.GroupId.HasValue && group.Contains(x.GroupId.Value)).ToList();
            }
            if (!String.IsNullOrEmpty(sRoom))
            {
                var rooms = _db.Rooms.ToList().Where(x => x.Name.Contains(sRoom)).Select(x => (int?)x.Id);
                events = events.Where(x => x.RoomId.HasValue && rooms.Contains(x.RoomId.Value)).ToList();
            }
            if (!String.IsNullOrEmpty(sInitiator))
            {
                var users = _db.Users.ToList().Where(x => x.LastName.Contains(sInitiator)).Select(x => (int?)x.Id);
                events = events.Where(x => x.InitiatorId.HasValue && users.Contains(x.InitiatorId.Value)).ToList();
            }

            switch (sortOrder)
            {
                case "type_desc":
                    events = events.OrderByDescending(s => s.TypeOfEvent);
                    break;
                case "initiator_desc":
                    events = events.OrderBy(s => s.InitiatorId);
                    break;
                case "room_desc":
                    events = events.OrderByDescending(s => s.RoomId);
                    break;
                case "group_desc":
                    events = events.OrderByDescending(s => s.GroupId);
                    break;
                default:
                    events = events.OrderBy(s => s.RoomId);
                    break;
            }

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

            return View(model.ToList());
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