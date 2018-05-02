using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Schedule.IntIta.BusinessLogic;
using Schedule.IntIta.DataAccess.Context;
using Schedule.IntIta.Domain.Models;
using Schedule.IntIta.ViewModels;

namespace Schedule.IntIta.Controllers
{
    [Authorize]
    public class ScheduleController : Controller
    {
        private readonly IEventBusinessLogic _eventBusinessLogic;
        private readonly IMapper _mapper;
        private readonly IntitaDbContext _db;
        public ScheduleController(IEventBusinessLogic eventBusinessLogic, IMapper mapper, IntitaDbContext db)
        {
            _db = db;
            _mapper = mapper;
            _eventBusinessLogic = eventBusinessLogic;
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
        [ValidateAntiForgeryToken]
        public JsonResult GetEventsForSchedule(FilterEvents filtersEvents = null)
        {
            List<CalendarEventViewModel> list = new List<CalendarEventViewModel>();
            List<Group> groups = (List<Group>)_eventBusinessLogic.GetAllGroups();

            var initiatorFilter = filtersEvents.InitiatorName;
            var eventTypeFilter = filtersEvents.TypeOfEvent;
            var roomFilter = filtersEvents.RoomName;
            var groupFilter = filtersEvents.GroupName;

            var events = _eventBusinessLogic
                .GetActive()
                .Where(@event =>
                    initiatorFilter != null ?
                        (@event.InitiatorId != null
                         &&
                         _eventBusinessLogic.FindUsers(initiatorFilter.ToUpper())
                             .Select(w => w.Id)
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
                calendarEvent.Subject = _db.Subjects.Single(x => x.Id == item.SubjectId);
                list.Add(calendarEvent);
            }

            return new JsonResult(list);
        }
    }
}