using MvcApplication4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication4.Controllers
{
    [Session]
    public class CustomerController : Controller
    {
        //
        // GET: /Custumer/

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [Session]
        [HttpPost]
        public ActionResult Add(Customer b)
        {
            b.Add();
            return View();
        }

        [HttpGet]
        public ActionResult ShowAll()
        {
            List<Customer> l = new List<Customer>();
            return View(new Customer().ShowAll());

        }
        [HttpGet]
        public ActionResult Update(int ID)
        {
            Customer B = new Customer()
            {
                CustomerID = ID
            };
            return View(B.Search());

        }
        [HttpPost]
        public ActionResult Update(Customer b)
        {
            b.Update();
            return RedirectToAction("ShowAll");

        }
        [HttpGet]
        public ActionResult Delete(int ID)
        {
            Customer p = new Customer();
            p.CustomerID = ID;
            p.Delete();
            return RedirectToAction("ShowAll");
        }
    }
}
