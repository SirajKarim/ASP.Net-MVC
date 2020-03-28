using MvcApplication4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication4.Controllers
{
    public class PaymentController : Controller
    {
        //
        // GET: /Payment/

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Payment b)
        {
            b.Add();
            return View();
        }

        [HttpGet]
        public ActionResult ShowAll()
        {
            List<Payment> l = new List<Payment>();
            return View(new Payment().ShowAll());

        }
        [HttpGet]
        public ActionResult Update(int ID)
        {
            Payment B = new Payment()
            {
                CostummerID = ID
            };
            return View(B.Search());

        }
        [HttpPost]
        public ActionResult Update(Payment b)
        {
            b.Update();
            return RedirectToAction("ShowAll");

        }
        [HttpGet]
        public ActionResult Delete(int ID)
        {
            Payment p = new Payment();
            p.CostummerID = ID;
            p.Delete();
            return RedirectToAction("ShowAll");
        }
    }
}


