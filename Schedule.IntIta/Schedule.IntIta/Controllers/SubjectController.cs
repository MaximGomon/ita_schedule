using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Schedule.IntIta.Domain.Models;
using AutoMapper;
using Schedule.IntIta.BusinessLogic;
using Schedule.IntIta.DataAccess;
using Schedule.IntIta.ViewModels;

namespace Schedule.IntIta.Controllers
{
    public class SubjectController : Controller
    {
        private readonly IMapper _mapper;

        public SubjectController(IMapper mapper)
        {
            _mapper = mapper;
        }
        public ActionResult Index()
        {
            SubjectRepository subjectR = new SubjectRepository();
            return View(subjectR.GetAll());
        }
        public ActionResult Create()
        {
            return View();
        }
        // POST: Room/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubjectViewModel model)
        {
            Subject sub = Mapper.Map<SubjectViewModel, Subject>(model);
            try
            {
                SubjectRepository subjectR = new SubjectRepository();
                SubjectBusinessLogic subjectBL = new SubjectBusinessLogic(subjectR);
                subjectBL.Add(sub);
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
                SubjectRepository subjectR = new SubjectRepository();
                SubjectBusinessLogic subjectBL = new SubjectBusinessLogic(subjectR);
                SubjectViewModel sub = Mapper.Map<Subject, SubjectViewModel> (subjectBL.Get(id));
                return View(sub);
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SubjectViewModel model)
        {
            Subject sub = Mapper.Map<SubjectViewModel, Subject>(model);
            try
            {
                SubjectRepository subjectR = new SubjectRepository();
                SubjectBusinessLogic subjectBL = new SubjectBusinessLogic(subjectR);
                subjectBL.Update(sub);
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
                SubjectRepository subjectR = new SubjectRepository();
                SubjectBusinessLogic subjectBL = new SubjectBusinessLogic(subjectR);
                SubjectViewModel sub = Mapper.Map<Subject, SubjectViewModel>(subjectBL.Get(id));
                return View(sub);
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
                SubjectRepository subjectR = new SubjectRepository();
                SubjectBusinessLogic subjectBL = new SubjectBusinessLogic(subjectR);
                subjectBL.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}