using MvcApplication4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication4.Controllers
{
    public class ContactUsController : Controller
    {
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(ContactUs b)
        {
            b.Add();
            return View();
        }

        [HttpGet]
        public ActionResult ShowAll()
        {
            List<ContactUs> l = new List<ContactUs>();
            return View(new ContactUs().ShowAll());

        }
    }
}