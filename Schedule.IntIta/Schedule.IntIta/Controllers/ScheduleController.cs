using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Schedule.IntIta.BusinessLogic;
using Schedule.IntIta.Domain.Models;
using Schedule.IntIta.ViewModels;

namespace Schedule.IntIta.Controllers
{
    [Authorize]
    public class ScheduleController : Controller
    {
        private readonly IEventBusinessLogic _eventBusinessLogic;
        private readonly IMapper _mapper;
        public ScheduleController(IEventBusinessLogic eventBusinessLogic, IMapper mapper)
        {
            _eventBusinessLogic = eventBusinessLogic;
            _mapper = mapper;
        }
        public IActionResult Index(int?RoomId = null)
        {
            string myCookie = Request.Cookies["RoomIdCookie"];
            if (myCookie != null)
            {
                int roomId = Int32.Parse(myCookie);
                FilterEvents filterEvents = new FilterEvents
                {
                    RoomName = _eventBusinessLogic.GetRoomById(roomId).Name
                };
                return RedirectToAction("Filter", "Event", filterEvents);
            }
           
            return View();
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
                        initiatorFilter != null ?
                        (@event.InitiatorId != null
                        &&
                        _eventBusinessLogic.FindUsers(initiatorFilter.ToUpper())//search users at INTITA
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
}