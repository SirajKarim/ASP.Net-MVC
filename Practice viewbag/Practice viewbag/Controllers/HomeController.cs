using Practice_viewbag.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practice_viewbag.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            //ViewBag.Name = "Muhammad Siraj";
            //ViewBag.age = "20";

            //string[] names = {"Muhammad Siraj","Muhammad Shoaib","Hamza","Shayan","Kamran" };
            //ViewBag.namelist = names;

            //Student st1 = new Student() {Id=61917,Name="Muhammad Siraj" };
            //ViewBag.Student = st1;
            List<Student> stdlst = new List<Student>();
            Student st1 = new Student() { Id = 61917, Name = "Muhammad Siraj" };
            Student st2 = new Student() { Id = 61918, Name = "Faizan" };
            stdlst.Add(st1);
            stdlst.Add(st2);
            ViewBag.StudentList = stdlst;
           return View();
        }

    }
}
