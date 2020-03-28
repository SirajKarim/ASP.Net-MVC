using MvcApplication4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication4.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/

        
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
     
        [HttpPost]
        public ActionResult Add(Employee b)
        {
            b.Add();
            return View();
        }

        [HttpGet]
        public ActionResult ShowAll()
        {
            List<Employee> l = new List<Employee>();
            return View(new Employee().ShowAll());

        }
        [HttpGet]
        public ActionResult Update(int ID)
        {
            Employee B = new Employee()
            {
                EmployeeID = ID
            };
            return View(B.Search());

        }
        //[HttpPost]
        //public ActionResult Update(Employee b)
        //{
        //    b.Update();
        //    return RedirectToAction("ShowAll");

        //}
        [HttpGet]
        public ActionResult Delete(int ID)
        {
            Employee p = new Employee();
            p.EmployeeID = ID;
            p.Delete();
            return RedirectToAction("ShowAll");
        }
    }
}
