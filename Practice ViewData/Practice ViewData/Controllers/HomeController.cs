using Practice_ViewData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practice_ViewData.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            //ViewData["Name"] = "Muhammad Siraj ";
            //ViewData["FatherName"] = "AbdulKarim";

            //string[] names = { "Kamran","Shayan","Hamza"};
            //ViewData["Names"] = names;

            Student st1 = new Student() { Name="Muhammad Siraj", FatherName="AbdulKarim"};
            Student st2 = new Student() { Name = "Muhammad Faizan", FatherName = "Aslam" };
            List<Student> stdlst = new List<Student>();
            stdlst.Add(st1);
            stdlst.Add(st2);

            ViewData["NameList"] = stdlst;
            return View();
        }

    }
}
