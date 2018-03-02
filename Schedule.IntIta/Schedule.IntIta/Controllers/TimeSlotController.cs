using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Schedule.IntIta.Domain.Models;
using Schedule.IntIta.ViewModels;
using Schedule.IntIta.DataAccess;
using Schedule.IntIta.BusinessLogic;

namespace Schedule.IntIta.Controllers
{
    public class TimeSlotController : Controller
    {
        private readonly IMapper _mapper;
        public TimeSlotController(IMapper mapper)
        {
            _mapper = mapper;

        }
        // GET: TimeSlot
        public ActionResult Index()
        {
            TimeSlot morningTimeSlot = new TimeSlot
            {
                Id = 1,
                StartTime = new DateTime(2018, 3, 1, 8, 0, 0),
                EndTime = new DateTime(2018, 3, 1, 12, 15, 0),
                IdType = new TimeSlotTypes().Id,
                IsDeleted = false
            };
            TimeSlot eveningTimeSlot = new TimeSlot
            {
                Id = 2,
                StartTime = new DateTime(2018, 3, 1, 18, 0, 0),
                EndTime = new DateTime(2018, 3, 1, 21, 15, 0),
                IdType = new TimeSlotTypes().Id,
                IsDeleted = false
            };
            TimeSlot eventTimeSlot = new TimeSlot
            {
                Id = 3,
                StartTime = new DateTime(2018, 4, 1, 10, 0, 0),
                EndTime = new DateTime(2018, 3, 1, 14, 0, 0),
                IdType = new TimeSlotTypes().Id,
                IsDeleted = false
            };
            List<TimeSlot> timeSlots = new List<TimeSlot> { morningTimeSlot, eveningTimeSlot,eventTimeSlot};
            return View(timeSlots);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // GET: TimeSlot/Create
        public ActionResult Create(TimeSlotViewModel tsModel)
        {
            TimeSlot tSlot = Mapper.Map<TimeSlotViewModel, TimeSlot>(tsModel);
            try
            {
                Console.WriteLine("Something happened");
                TimeSlotRepository tsRepo = new TimeSlotRepository();
                TimeSlotBuisnessLogic tsBLogic = new TimeSlotBuisnessLogic(tsRepo);
                tsRepo.Insert(tSlot);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
            
        }

        // GET: TimeSlot/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TimeSlot/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TimeSlot/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TimeSlot/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}