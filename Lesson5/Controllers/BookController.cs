using Lesson5.Models;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lesson5.Controllers
{
    /// <summary>

    /// </summary>
    public class BookController : Controller
    {
        // GET: Book
        [HttpGet]
        public ActionResult Add_Book()
        {
            string a = ViewBag._Name;
            a = (string)Session["Lib_Names"];
            ViewBag.i = a;
            return View();
        }

        [HttpPost]
        public ActionResult Add_Book(Book b)
        {

            b.Add();
            return View();

        }
      
        [HttpGet]
        public ActionResult Update(string isbn)
        {
            Book b = new Book();
            b.ISBN = isbn;
            Book search_Book = b.Search();
            return View(search_Book);
        }
        [HttpPost]
        public ActionResult Update(Book b)
        {
            b.Update();
            return RedirectToAction("ShowAll");
        }
        [HttpGet]
        public ActionResult Delete(string isbn)
        {
            Book b = new Book();
            b.ISBN = isbn;
            b.Delete();
            return RedirectToAction("ShowAll");
        }
        [HttpGet]
        public ActionResult Details(string isbn)
        {
            Book b = new Book();
            b.ISBN = isbn;
            Book search_Book = b.Search();
            return View(search_Book);
        }

        public static bool check = false;
        public ActionResult New_Action(string abc)
        {
            check = true;
            Book b = new Book();
            b.ISBN = abc;
            Search_book=b.Search();
            object a = Session["j"];
            return RedirectToAction("ShowAll");
        }
        public static Book Search_book = new Book();
        [HttpGet]
        public ActionResult ShowAll()
        {
            List<Book> ls = new Book().ShowAll();
            ViewBag.i = "Hello World";
            ViewData["j"] = "HELLO WORLD";

            Session["a"] = "Kesa hai";

            if (check)
            {
                List<Book> lst = new List<Book>() { Search_book };
                check = false;
                return View(lst);
            }
            if (Sorted_Books != null)
            {
                return View(Sorted_Books);
            }
            return View(new Book().ShowAll());
        }
        public static List<Book> Sorted_Books;
        public ActionResult sort(string abc)
        {
            Sorted_Books = new Book().Sorting(abc);
            return RedirectToAction("ShowAll");
        }
        public ActionResult Show()
        {

            return View(new Book().ShowAll());
        }
        public ActionResult Shoow()
        {
            //ViewBag.Library_Name = "Oxford Library";
            //ViewBag._Name = "Gulam Ahmed Library"; 
            //ViewData["Name"] = "Larkana Library";


            if (Account.Check)
            {
                Session["Lib_Names"] = "Kala Bagh Library";
                //  ViewBag.i = new Book().ShowAll();

                return View(new Book().ShowAll());
            }
            return RedirectToAction("Login", "Session");
        }
        public ActionResult Generate_Report()
        {
            return View();
        }

        public ActionResult Report()
        {
            LocalReport lr = new LocalReport();
            lr.ReportPath = Server.MapPath("~/Report/Report1.rdlc");
            ReportDataSource rd = new ReportDataSource("abc", new Book().ShowAll());
            lr.DataSources.Add(rd);
            byte[] render = lr.Render("PDF");
            return File(render,"application/pdf");




          //  string reportType = "PDF";
          //  string mimeType, encoding, fileNameExtension;


          //  string deviceinfo =
          //       "<DeviceInfo>" +
          //"  <OutputFormat>EMF</OutputFormat>" +
          //"  <PageWidth>10in</PageWidth>" +
          //"  <PageHeight>11in</PageHeight>" +
          //"  <MarginTop>0.25in</MarginTop>" +
          //"  <MarginLeft>0.25in</MarginLeft>" +
          //"  <MarginRight>0.25in</MarginRight>" +
          //"  <MarginBottom>0.25in</MarginBottom>" +
          //"</DeviceInfo>";

          //  Warning[] warnings;
          //  string[] streams;
          //  byte[] renderedBytes;

          //  renderedBytes = lr.Render(reportType, deviceinfo,out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
          //  object t=File(renderedBytes, "application/pdf");
          //  return File(renderedBytes, "application/pdf");
        }


    }
}