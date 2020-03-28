using MvcApplication4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication4.Controllers
{
    public class OrderController : Controller
    {
        //
        // GET: /Order/

         [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Order b)
        {
            b.Add();
            return View();
        }

        [HttpGet]
        public ActionResult ShowAll()
        {
            List<Order> l = new List<Order>();
            return View(new Order().ShowAll());

        }
        [HttpGet]
        public ActionResult Update(int ID)
        {
            Order B = new Order()
            {
                CostumerID = ID
            };
            return View(B.Search());

        }
        [HttpPost]
        public ActionResult Update(Order b)
        {
            b.Update();
            return RedirectToAction("ShowAll");

        }
        [HttpGet]
        public ActionResult Delete(int ID)
        {
            Order p = new Order();
            p.CostumerID = ID;
            p.Delete();
            return RedirectToAction("ShowAll");
        }
    }
}


