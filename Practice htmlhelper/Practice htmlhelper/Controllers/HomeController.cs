﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practice_htmlhelper.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(double firstnumber,double secondnumber)
        {
            double result = firstnumber + secondnumber;
            ViewBag.Result = result;
            return View();
        }

    }
}
