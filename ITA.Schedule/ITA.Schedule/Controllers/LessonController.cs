using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITA.Schedule.DAL;
using ITA.Schedule.Models;

namespace ITA.Schedule.Controllers
{
    public class LessonController : Controller
    {
        // GET: Lesson
        [HttpGet]
        public ActionResult Index()
        {
            var newLesson = new LessonViewModel()
            {
                TeacherList = new List<SelectListItem>
                {
new SelectListItem()
{
    Text = "Gomon Maxim",
    Value = "13"
},
new SelectListItem()
{
    Text = "Gomon Maxi",
    Value = "14"
},
new SelectListItem()
{
    Text = "Gomon Maxi",
    Value = "15"
},
new SelectListItem()
{
    Text = "Gomon Maxim",
    Value = "13"
},
            new SelectListItem()
        {
            Text = "Gomon Maxim",
            Value = "13"
        }
                }
            };
            return View("Lesson", newLesson);
        }

        //[HttpPost]
        //public ActionResult Index(Guid id)
        //{
        //    return PartialView("/Views/Lesson/Lesson.cshtml");
        //}

        public JsonResult GetSubjects(Guid id)
        {
            using (var context = new ScheduleDbContext())
            {
                var subjects = context.Subjects.Where(x => x.Teachers.Any(y => y.Id == id)).ToList();

                return Json(subjects.Select(x=>x.Id));
            }
        }
    }
}