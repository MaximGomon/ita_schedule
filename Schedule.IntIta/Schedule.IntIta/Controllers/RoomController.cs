using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Schedule.IntIta.BusinessLogic;
using Schedule.IntIta.DataAccess;
using Schedule.IntIta.ViewModels;

namespace Schedule.IntIta.Controllers
{
    public class RoomController : Controller
    {
        private readonly IMapper _mapper;

        public RoomController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            RoomBusinessLogic roomBusinessLogic = new RoomBusinessLogic(new RoomRepository());
            var rooms = roomBusinessLogic.GetAll();
            List<RoomViewModel> model = new List<RoomViewModel>();

            foreach (var item in rooms)
            {
                model.Add(_mapper.Map<RoomViewModel>(item));
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
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

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

            return View();
        }

        // POST: Room/Edit/5
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

        // GET: Room/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Room/Delete/5
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