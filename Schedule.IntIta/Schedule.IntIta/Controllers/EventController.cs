﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Schedule.IntIta.BusinessLogic;
using Schedule.IntIta.Cache.Cache;
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

        [HttpGet]
        public ActionResult FilterShow()
        {
            return View(nameof(Index), _eventBusinessLogic.GetAll().Select(_mapper.Map<EventViewModel>));
        }


        [HttpPost]
        //[CheckContentFilter]
        public ActionResult Filter([FromBody]List<FilterEvents> filterOptions)
        {
            List<EventViewModel> models = new List<EventViewModel>();

            var initiatorFilter = filterOptions.FirstOrDefault(x => x.EventField == "InitiatorName");
            var eventTypeFilter = filterOptions.FirstOrDefault(x => x.EventField == "TypeOfEvent");
            var RoomFilter = filterOptions.FirstOrDefault(x => x.EventField == "RoomName");
            var GroupFilter = filterOptions.FirstOrDefault(x => x.EventField == "GroupName");

            var events = _eventBusinessLogic
                .GetAll()
                .Where(@event =>
                    initiatorFilter != null ?
                    (@event.InitiatorId != null
                    &&
                    _eventBusinessLogic.FindUsers(initiatorFilter.SearchString)//search users at INTITA
                        .Select(w => w.Id)//select only Ids of find users
                        .Contains(@event.InitiatorId.Value)
                    &&
                    eventTypeFilter != null ?
                    (@event.TypeOfEvent != null
                    &&
                    @event.TypeOfEvent.Name.Contains(eventTypeFilter.SearchString)) : true
                    &&
                    RoomFilter != null ?
                    (@event.RoomId != null
                    &&
                    _eventBusinessLogic.GetAllRooms().Select(w => w.Id).Contains(@event.RoomId.Value)) : true
                    &&
                    GroupFilter != null ?
                    (@event.GroupId != null
                    &&
                    _eventBusinessLogic.GetAllGroups().Select(w => w.Id).Contains(@event.GroupId.Value)) : true) : true);

            foreach (var item in events)
            {
                models.Add(_mapper.Map<EventViewModel>(item));
            }

            models = models.OrderBy(x => x.Date.StartTime).ToList();
            ViewData["FilterSettings"] = filterOptions;
            return View(nameof(Index), models);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string myCookie = Request.Cookies["SomeCustomCookie"];
            //List<FilterEvents> filters = new List<FilterEvents>();
            return RedirectToAction("FilterShow");
        }

        // GET: Room/Create
        public ActionResult Create()
        {
            //TODO: перенести все в репозиторий
            SelectList eventTypes = new SelectList(_db.EventTypes, "Id", "Name");
            SelectList timeSlotTypes = new SelectList(_db.TimeSlotTypes, "Id", "Type");
            SelectList userSelectList = new SelectList(_eventBusinessLogic.FindUsers(""), "Id", "LastName");
            SelectList roomSelectList = new SelectList(_db.Rooms, "Id", "Name");
            SelectList groupSelectList = new SelectList(_eventBusinessLogic.GetAllGroups(), "Id", "Name");
            SelectList subjectSelectList = new SelectList(_db.Subjects, "Id", "Name");

            ViewData["eventTypes"] = eventTypes;
            ViewData["timeSlotTypes"] = timeSlotTypes;
            ViewData["subjectSelectList"] = subjectSelectList;
            ViewData["userSelectList"] = userSelectList;
            ViewData["roomSelectList"] = roomSelectList;
            ViewData["groupSelectList"] = groupSelectList;

            return View();
        }

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

        public JsonResult GetActiveEvents()
        {
            var events = _eventBusinessLogic.GetActive();
            List<CalendarEventViewModel> list = new List<CalendarEventViewModel>();
            List<Group> groups = (List<Group>)_eventBusinessLogic.GetAllGroups();

            foreach (var item in events)
            {
                var calendarEvent = _mapper.Map<CalendarEventViewModel>(item);
                //calendarEvent.Group = _eventBusinessLogic.GetAllGroups().FirstOrDefault(x => x.Id == item.GroupId);
                calendarEvent.Group = groups.FirstOrDefault(x => x.Id == item.GroupId);
                //calendarEvent.Group = _eventBusinessLogic.GetGroupById(item.GroupId);
                //calendarEvent.Group = _db.Groups.Single(x => x.Id == item.GroupId);
                calendarEvent.Initiator = _eventBusinessLogic.GetUsersById(item.InitiatorId);
                //calendarEvent.Initiator = _db.Users.Single(x => x.Id == item.InitiatorId);
                calendarEvent.Room = _eventBusinessLogic.GetAllRooms().FirstOrDefault(w => w.Id == item.RoomId);
                //calendarEvent.Room = _db.Rooms.Single(x => x.Id == item.RoomId);
                calendarEvent.Subject = _db.Subjects.Single(x => x.Id == item.SubjectId);
                list.Add(calendarEvent);
            }

            return new JsonResult(list);
        }
    }

    public class CheckContentFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            using (var stream = new MemoryStream())
            {
                context.HttpContext.Request.Body.CopyTo(stream);
                stream.Position = 0;
                var bytes = new byte[stream.Length];
                stream.Read(bytes, 0, bytes.Length);
                var text = Encoding.Default.GetString(bytes);

            }
        }
    }
}