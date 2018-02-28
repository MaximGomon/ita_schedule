using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Schedule.IntIta.Domain.Models;
using AutoMapper;
using Schedule.IntIta.BusinessLogic;
using Schedule.IntIta.DataAccess;

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
            Subject room1 = new Subject
            {
                Id = 1,
                Name = "Subj 1"
            };
            Subject room2 = new Subject
            {
                Id = 2,
                Name = "Subj 2"
            };

            List<Subject> model = new List<Subject> { room1, room2 };

            return View(model);
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
                Console.WriteLine("sdfdfas");
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

            return View();
        }
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
        public ActionResult Delete(int id)
        {
            return View();
        }
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