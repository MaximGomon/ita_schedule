﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Schedule.IntIta.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }

        
        public IActionResult SearchResult(int id)
        {
            ViewBag.UserId = id;
            return View();
        }
    }
}