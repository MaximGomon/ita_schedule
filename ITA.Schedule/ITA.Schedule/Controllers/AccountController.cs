using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITA.Schedule.BLL.Implementations;
using ITA.Schedule.DAL.Repositories.Implementations;
using ITA.Schedule.Entity.Entities;
using ITA.Schedule.Models;

namespace ITA.Schedule.Controllers
{
    

    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Show()
        {
            var people = new PeopleViewModel();

            var teaccherBl = new TeacherBl(new TeacherRepository());
            var teacher = teaccherBl.Get(t => t.Name == "Maxim Gomon")
                .Include(t => t.Subjects)
                .Include(t => t.TeacherAllTimes)
                .FirstOrDefault();

            if (teacher != null)
            {
                people.Name = teacher.Name;
                people.SubGroup = null;
                people.About = "Hello I’m " + people.Name +
                               "I am a teacher In ITA. I teach .Net/C#. " +
                               "My Graduation From Vinnitsya National Technical University " +
                               "With A Bachelor Of Design Majoring In Visual Communication.";

                people.Email = "flymandude@gmail.com";
                people.FacebookUrl = "https://www.facebook.com/max.gomon.3";
                people.VkUrl = "https://dou.ua/users/maksim-gomon/";
                people.GithubUrl = "https://github.com/MaximGomon";
                people.Phone = 930455425;
                people.City = "Vinnitsya";
                people.Position = (teacher.GetType().Name).Split('_')[0];
                people.Expierience = 6;
                people.Subjects = teacher.Subjects.ToList();
                people.TeacherAllTimes = teacher.TeacherAllTimes.ToList();
                people.PhotoUri = "https://scontent-frt3-1.xx.fbcdn.net/v/t1.0-1/p160x160/14199434_1114002838677106_519506904949999246_n.jpg?oh=c65d189dfa17fb90fb106ef0529ad921&oe=58B6E9BA";


            }

            return View("Account", people);

        }
    }


    
}