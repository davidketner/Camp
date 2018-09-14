﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Camp.Web.Models;
using Camp.Data;
using Camp.Data.Entity;

namespace Camp.Web.Controllers
{
    public class HomeController : BaseController
    {

        public HomeController(ICampService svc) : base(svc)
        {

        }

        public IActionResult Index()
        {
            Svc.CreateDiet(new Diet { Name = "Oběd", PersonPrice = 250, ChildrenPrice = 200 });
            Svc.Commit();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
