using Lesson5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Lesson5.Controllers
{
    public class MovieController : Controller
    {
        [HttpGet]
        public ActionResult Dropdowns()
        {
            ViewBag.i = new Movie().Show();
            ViewBag.j = new Show().ShowAll();
            return View();
        }

        [HttpGet]
        public ActionResult Show_Shows(int M_ID)
        {

            return Json(new Show().Shows(M_ID), JsonRequestBehavior.AllowGet);

        }
    }
}