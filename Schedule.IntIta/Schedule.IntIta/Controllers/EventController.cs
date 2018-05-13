using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
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
        private readonly IEventBusinessLogic _eventBusinessLogic;

        public EventController(IMapper mapper, IEventBusinessLogic eventBusinessLogic, IntitaDbContext db)
        {
            _mapper = mapper;
            _eventBusinessLogic = eventBusinessLogic;
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Filter(FilterEvents filtersEvents)
        {
            List<EventViewModel> models = new List<EventViewModel>();

            var initiatorFilter = filtersEvents.InitiatorName;
            var eventTypeFilter = filtersEvents.TypeOfEvent;
            var roomFilter = filtersEvents.RoomName;
            var groupFilter = filtersEvents.GroupName;

            var events = _eventBusinessLogic
                    .GetAll()
                    .Where(@event =>
                        FilterByInitiator(@event, initiatorFilter)
                        &&
                        FilterByTypeOfEvent(@event, eventTypeFilter)
                        &&
                        FilterByRoom(@event, roomFilter)
                        &&
                        FilterByGroup(@event, groupFilter)
                ).ToList();

            foreach (var item in events)
            {
                models.Add(_mapper.Map<EventViewModel>(item));
            }
            ViewBag.Data = models.OrderBy(x => x.Date.StartTime).ToList();
            
            return View(nameof(Index));
        }

        [HttpPost]
        public ActionResult GetEventsForSchedule(FilterEvents filtersEvents = null)
        {
            List<EventViewModel> models = new List<EventViewModel>();

            var initiatorFilter = filtersEvents.InitiatorName;
            var eventTypeFilter = filtersEvents.TypeOfEvent;
            var roomFilter = filtersEvents.RoomName;
            var groupFilter = filtersEvents.GroupName;

            List<CalendarEventViewModel> list = new List<CalendarEventViewModel>();
            List<Group> groups = (List<Group>)_eventBusinessLogic.GetAllGroups();

            var events = _eventBusinessLogic
                    .GetAll()
                    .Where(@event =>
                    FilterByInitiator(@event, initiatorFilter)
                    &&
                    FilterByTypeOfEvent(@event, eventTypeFilter)
                    &&
                    FilterByRoom(@event, roomFilter)
                    &&
                    FilterByGroup(@event, groupFilter))
                .ToList();
            foreach (var item in events)
            {
                var calendarEvent = _mapper.Map<CalendarEventViewModel>(item);
                calendarEvent.Group = groups.FirstOrDefault(x => x.Id == item.GroupId);
                calendarEvent.Initiator = _eventBusinessLogic.GetUsersById(item.InitiatorId);
                calendarEvent.Room = _eventBusinessLogic.GetAllRooms().FirstOrDefault(w => w.Id == item.RoomId);
                calendarEvent.Subject = _eventBusinessLogic.GetSubjects().Single(x => x.Id == item.SubjectId);
                list.Add(calendarEvent);
            }
            return new JsonResult(list);
        }

        private bool FilterByInitiator(Event @event, string initiatiorName)
        {
            if (String.IsNullOrEmpty(initiatiorName))
                return true;

            if (@event.InitiatorId == null)
                return false;

            var user = _eventBusinessLogic.FindLocalUsers(initiatiorName.ToUpper());

            if(user.Select(x => x.Id).ToList().Contains(@event.InitiatorId.Value))
            {
                return true;
            }

            return false;
        }

        private bool FilterByTypeOfEvent(Event @event, string eventTypeFilter)
        {
            if (String.IsNullOrEmpty(eventTypeFilter))
                return true;
            if (@event.TypeOfEvent == null)
                return false;
            if (@event.TypeOfEvent.Name.Contains(eventTypeFilter))
                return true;
            return false;
        }

        private bool FilterByRoom(Event @event, string roomFilter)
        {
            if (String.IsNullOrEmpty(roomFilter))
                return true;
            if (@event.RoomId == null)
                return false;
            var room = _eventBusinessLogic.GetRoomById(@event.RoomId.Value);
            if (room.Name.Contains(roomFilter))
                return true;
            return false;
        }

        private bool FilterByGroup(Event @event, string groupName)
        {
            if (String.IsNullOrEmpty(groupName))
                return true;
            if (@event.GroupId == null)
                return false;
            var group = _eventBusinessLogic.GetGroupById(@event.GroupId.Value);
            if (group.Name.Contains(groupName))
                return true;
            return false;
        }


        public ActionResult Index()
        {
            ViewBag.Data = _eventBusinessLogic.GetAll().Select(_mapper.Map<EventViewModel>);
            return View();
        }

        // GET: Room/Create
        public ActionResult Create()
        {
            SelectList eventTypes = new SelectList(_eventBusinessLogic.GetEventTypes(), "Id", "Name");
            SelectList timeSlotTypes = new SelectList(_eventBusinessLogic.GetTimeSlotTypes(), "Id", "Type");
            SelectList userSelectList = new SelectList(_eventBusinessLogic.FindUsers(""), "Id", "LastName");
            SelectList roomSelectList = new SelectList(_eventBusinessLogic.GetRooms(), "Id", "Name");
            SelectList groupSelectList = new SelectList(_eventBusinessLogic.GetAllGroups(), "Id", "Name");
            SelectList subjectSelectList = new SelectList(_eventBusinessLogic.GetSubjects(), "Id", "Name");
            SelectList repeatTypesSelectList = new SelectList(_eventBusinessLogic.GetRepeatTypes(), "Id", "Type");

            ViewData["eventTypes"] = eventTypes;
            ViewData["timeSlotTypes"] = timeSlotTypes;
            ViewData["subjectSelectList"] = subjectSelectList;
            ViewData["userSelectList"] = userSelectList;
            ViewData["roomSelectList"] = roomSelectList;
            ViewData["groupSelectList"] = groupSelectList;
            ViewData["repeatTypes"] = repeatTypesSelectList;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventViewModel eventViewModel)
        {
            try
            {
                var s = _mapper.Map<Event>(eventViewModel);
                _eventBusinessLogic.Add(s);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                return View();
            }
        }

        // GET: Room/Edit/5
        public ActionResult Edit(int id)
        {
            SelectList eventTypes = new SelectList(_eventBusinessLogic.GetEventTypes(), "Id", "Name");
            SelectList timeSlotTypes = new SelectList(_eventBusinessLogic.GetTimeSlotTypes(), "Id", "Type");
            SelectList userSelectList = new SelectList(_eventBusinessLogic.FindUsers(""), "Id", "LastName");
            SelectList roomSelectList = new SelectList(_eventBusinessLogic.GetRooms(), "Id", "Name");
            SelectList groupSelectList = new SelectList(_eventBusinessLogic.GetAllGroups(), "Id", "Name");
            SelectList subjectSelectList = new SelectList(_eventBusinessLogic.GetSubjects(), "Id", "Name");
            SelectList repeatTypesSelectList = new SelectList(_eventBusinessLogic.GetRepeatTypes(), "Id", "Type");

            ViewData["eventTypes"] = eventTypes;
            ViewData["timeSlotTypes"] = timeSlotTypes;
            ViewData["subjectSelectList"] = subjectSelectList;
            ViewData["userSelectList"] = userSelectList;
            ViewData["roomSelectList"] = roomSelectList;
            ViewData["groupSelectList"] = groupSelectList;
            ViewData["repeatTypes"] = repeatTypesSelectList;

            return View(_mapper.Map<EventViewModel>(_eventBusinessLogic.Read(id)));
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
                calendarEvent.Group = groups.FirstOrDefault(x => x.Id == item.GroupId);
                calendarEvent.Initiator = _eventBusinessLogic.GetUsersById(item.InitiatorId);
                calendarEvent.Room = _eventBusinessLogic.GetAllRooms().FirstOrDefault(w => w.Id == item.RoomId);
                calendarEvent.Subject = _eventBusinessLogic.GetSubjects().Single(x => x.Id == item.SubjectId);
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