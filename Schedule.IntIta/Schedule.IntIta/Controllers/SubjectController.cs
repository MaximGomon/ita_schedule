﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Schedule.IntIta.Domain.Models;
using AutoMapper;
using Schedule.IntIta.BusinessLogic;
using Schedule.IntIta.DataAccess;
using Schedule.IntIta.ViewModels;
using System.Linq;

namespace Schedule.IntIta.Controllers
{
    public class SubjectController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ISubjectBusinessLogic _subjectBusinessLogic;
        private readonly ISubjectRepository _subjectRepository;

        public SubjectController(IMapper mapper, ISubjectBusinessLogic subjectBusinessLogic)
        {
            _mapper = mapper;
            _subjectBusinessLogic = subjectBusinessLogic;
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
                _subjectBusinessLogic.Add(sub);
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
                SubjectViewModel sub = Mapper.Map<Subject, SubjectViewModel>(_subjectBusinessLogic.Read(id));
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
                _subjectBusinessLogic.Update(sub);
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
                SubjectViewModel sub = Mapper.Map<Subject, SubjectViewModel>(_subjectBusinessLogic.Read(id));
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
                _subjectBusinessLogic.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}