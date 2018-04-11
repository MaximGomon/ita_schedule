using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Schedule.IntIta.Domain.Models;
using Schedule.IntIta.Domain.Models.Enumerations;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Schedule.IntIta.BusinessLogic;
using Schedule.IntIta.DataAccess;
using Schedule.IntIta.ViewModels;

namespace Schedule.IntIta.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OfficeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IOfficeBusinessLogic _officeBusinessLogic;

        public OfficeController(IMapper mapper, IOfficeBusinessLogic officeBusinessLogic)
        {
            _mapper = mapper;
            _officeBusinessLogic = officeBusinessLogic;
        }

        public ActionResult Index()
        {
            OfficeRepository officeR = new OfficeRepository();
            return View(officeR.GetAll().Select(x =>
                Mapper.Map<Office, OfficeViewModel>(x)));
        }
        // GET: Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OfficeViewModel model)
        {
            Office office = Mapper.Map<OfficeViewModel, Office>(model);
            try
            {
                _officeBusinessLogic.Add(office);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            try
            {
                OfficeViewModel office = Mapper.Map<Office, OfficeViewModel>(_officeBusinessLogic.Read(id));
                return View(office);
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OfficeViewModel model)
        {
            Office office = Mapper.Map<OfficeViewModel, Office>(model);
            try
            {
                _officeBusinessLogic.Update(office);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            try
            {
                OfficeViewModel office = Mapper.Map<Office, OfficeViewModel>(_officeBusinessLogic.Read(id));
                return View(office);
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _officeBusinessLogic.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}