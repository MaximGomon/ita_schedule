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
        private readonly IEventBusinessLogic _eventBusinessLogic;
        private readonly IEventTypeBusinessLogic _eventTypeBusinessLogic;
        private readonly ITimeSlotTypeBusinessLogic _timeSlotTypeBusinessLogic;
        private readonly ISubjectBusinessLogic _subjectBusinessLogic;
        private readonly IRoomBusinessLogic _roomBusinessLogic;
        
        public EventController(
            IMapper mapper,
            IEventBusinessLogic eventBusinessLogic,
            IEventTypeBusinessLogic eventTypeBusinessLogic,
            ITimeSlotTypeBusinessLogic timeSlotTypeBusinessLogic,
            ISubjectBusinessLogic subjectBusinessLogic,
            IRoomBusinessLogic roomBusinessLogic)
        {
            _mapper = mapper;
            _eventBusinessLogic = eventBusinessLogic;
            _eventTypeBusinessLogic = eventTypeBusinessLogic;
            _timeSlotTypeBusinessLogic = timeSlotTypeBusinessLogic;
            _subjectBusinessLogic = subjectBusinessLogic;
            _roomBusinessLogic = roomBusinessLogic;
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
                        initiatorFilter != null ?
                        (@event.InitiatorId != null
                        &&
                        _eventBusinessLogic.FindLocalUsers(initiatorFilter.ToUpper())//search users at INTITA
                            .Select(w => w.Id)//select only Ids of find users
                            .Contains(@event.InitiatorId.Value)) : true
                        &&
                        eventTypeFilter != null ?
                        (@event.TypeOfEvent != null
                        &&
                        @event.TypeOfEvent.Name.ToUpper().Contains(eventTypeFilter.ToUpper())) : true
                        &&
                        roomFilter != null ?
                        (@event.RoomId != null
                        &&
                         _eventBusinessLogic.GetRoomById(@event.RoomId.Value).Name.ToUpper().Contains(roomFilter.ToUpper())) : true
                        &&
                        groupFilter != null ?
                        (@event.GroupId != null
                        &&
                         _eventBusinessLogic.GetGroupById(@event.GroupId.Value).Name.ToUpper().Contains(groupFilter.ToUpper())) : true).ToList();

            foreach (var item in events)
            {
                models.Add(_mapper.Map<EventViewModel>(item));
            }
            ViewBag.Data = models.OrderBy(x => x.Date.StartTime).ToList();
            
            return View(nameof(Index));
        }
        
        //[HttpGet]
        public IActionResult Index()
        {
            ViewBag.Data = _eventBusinessLogic.GetAll().Select(_mapper.Map<EventViewModel>).OrderBy(x => x.Date.StartTime).ToList();
            return View();
        }

        // GET: Room/Create
        public ActionResult Create()
        {
            SelectList eventTypes = new SelectList(_eventTypeBusinessLogic.GetAll(), "Id", "Name");
            SelectList timeSlotTypes = new SelectList(_timeSlotTypeBusinessLogic.GetAll(), "Id", "Type");
            SelectList roomSelectList = new SelectList(_roomBusinessLogic.GetAll(), "Id", "Name");
            SelectList groupSelectList = new SelectList(_eventBusinessLogic.GetAllGroups(), "Id", "Name");
            SelectList subjectSelectList = new SelectList(_subjectBusinessLogic.GetAll(), "Id", "Name");

            ViewData["eventTypes"] = eventTypes;
            ViewData["timeSlotTypes"] = timeSlotTypes;
            ViewData["subjectSelectList"] = subjectSelectList;
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
            SelectList eventTypes = new SelectList(_eventTypeBusinessLogic.GetAll(), "Id", "Name");
            SelectList timeSlotTypes = new SelectList(_timeSlotTypeBusinessLogic.GetAll(), "Id", "Type");
            SelectList roomSelectList = new SelectList(_roomBusinessLogic.GetAll(), "Id", "Name");
            SelectList groupSelectList = new SelectList(_eventBusinessLogic.GetAllGroups(), "Id", "Name");
            SelectList subjectSelectList = new SelectList(_subjectBusinessLogic.GetAll(), "Id", "Name");

            ViewData["eventTypes"] = eventTypes;
            ViewData["timeSlotTypes"] = timeSlotTypes;
            ViewData["subjectSelectList"] = subjectSelectList;
            ViewData["roomSelectList"] = roomSelectList;
            ViewData["groupSelectList"] = groupSelectList;

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
                calendarEvent.Subject = _subjectBusinessLogic.GetAll().Single(x => x.Id == item.SubjectId);
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