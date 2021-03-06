﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Norway.Models;

namespace Norway.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult FeedBack()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FeedBack(FeedBack feedBack)
        {
            if(ModelState.IsValid)
            {
                return View("Thanks", feedBack);
            }
            else
            {
                return View();
            }
        }
    }
}