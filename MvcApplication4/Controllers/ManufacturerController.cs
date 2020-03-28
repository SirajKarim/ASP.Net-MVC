using MvcApplication4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication4.Controllers
{
    [Session]
    public class ManufacturerController : Controller
    {
        //
        // GET: /Manufacturer/

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Manufacturer b)
        {
            b.Add();
            return View();
        }

        [HttpGet]
        public ActionResult ShowAll()
        {
            List<Manufacturer> l = new List<Manufacturer>();
            return View(new Manufacturer().ShowAll());

        }
        [HttpGet]
        public ActionResult Update(int ID)
        {
            Manufacturer B = new Manufacturer()
            {
                ManufacturerID = ID
            };
            return View(B.Search());

        }
        [HttpPost]
        public ActionResult Update(Manufacturer b)
        {
            b.Update();
            return RedirectToAction("ShowAll");

        }
        [HttpGet]
        public ActionResult Delete(int ID)
        {
            Manufacturer p = new Manufacturer();
            p.ManufacturerID = ID;
            p.Delete();
            return RedirectToAction("ShowAll");
        }
    }
}
