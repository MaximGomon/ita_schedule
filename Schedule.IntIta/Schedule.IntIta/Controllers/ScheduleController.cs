using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Schedule.IntIta.BusinessLogic;
using Schedule.IntIta.ViewModels;

namespace Schedule.IntIta.Controllers
{
    [Authorize]
    public class ScheduleController : Controller
    {
        private readonly IEventBusinessLogic _eventBusinessLogic;
        public ScheduleController(IEventBusinessLogic eventBusinessLogic)
        {
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
    }
}