using Lesson5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lesson5.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult Add_Students()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add_Students(Student s)
        {
            return View();
        }
        [HttpGet]
        public ActionResult Add_Books()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add_Books(Book s)
        {
            return View();
        }

















        [HttpPost]
        public ActionResult Add_Book()
        {
            ViewBag.i = new St_Cateogry().ShowAll();
            return View();
        }
        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.i = new St_Cateogry().ShowAll();
            return View();
        }

        [HttpPost]
        public ActionResult Add(Students st,HttpPostedFileBase file)
        {
            if(file!=null)
            {
                string imag_Name = System.IO.Path.GetFileName(file.FileName);
                string phy_path = Server.MapPath("~/Images/"+imag_Name);
                file.SaveAs(phy_path);
                st.Name = imag_Name;
                st.Add();
            
            }
            return RedirectToAction("shows");

        }
        public ActionResult shows()
        {
            List<Students> lst = new Students().ShowAll();
            ViewBag.i = lst;
            return View(lst);
        }

        [HttpGet]
        public ActionResult BigModel()
        {
          //  Tuple<List<Student>, List<Book> > l = new Tuple<List<Student>, List<Book>>(new Student().ShowAll(), new Book().ShowAll());
            return View();
        }
        [HttpPost]
        public ActionResult BigModel(Book b)
        {
            //Tuple<List<Student>, List<Book>> l = new Tuple<List<Student>, List<Book>>(new Student().ShowAll(), new Book().ShowAll());
            return View();
        }
        [HttpGet]
        public ActionResult S_Post()
        {
            return View();
        }
        [HttpPost]
        public ActionResult S_Post(Student s)
        {
            return View();
        }
        [HttpPost]
        public ActionResult B_Post(Book s)
        {
            return View();
        }






















        //[HttpGet]
        //public ActionResult Add_Student()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Add_Student(Student s, HttpPostedFileBase file)
        //{
        //    if (file != null)
        //    {

        //        string ImageName = System.IO.Path.GetFileName(file.FileName);
        //        string physicalPath = Server.MapPath("~/Images/" + ImageName);
        //        file.SaveAs(physicalPath);
        //        s.Image_Path = ImageName;
        //        s.Add();
        //    }
        //    return View();
        //}

        //[HttpGet]
        //public ActionResult Show()
        //{
        //    List<Student> lst = new Student().ShowAll();

        //    return View(lst);
        //}
    }
}