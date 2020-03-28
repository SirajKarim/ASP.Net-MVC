using Microsoft.Reporting.WebForms;
using OnlinePrintingSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlinePrintingSolution.Controllers
{
    public class Cust_FormController : Controller
    {
        //
        // GET: /Cust_Form/

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Customer cs)
        {
            cs.Add();
            return View();
        }


        [HttpGet]
         public ActionResult ShowAll()
         {
             
             return View(new Customer().ShowAll());
         }


        [HttpGet]
        public ActionResult Update(int CustomerId)
        {
            Customer cs = new Customer();
            cs.CustomerID = CustomerId;
            Customer search_book = cs.Search();
            return View(search_book);
        }
        [HttpPost]
        public ActionResult Update(Customer cs)
        {
            cs.Update();
            return RedirectToAction("ShowAll");
        }

        [HttpGet]
        public ActionResult Delete(int CustomerId)
        {
            Customer cs = new Customer();
            cs.CustomerID = CustomerId;
            cs.Delete();
            return RedirectToAction("ShowAll");
        }


        [HttpGet]
        public ActionResult Details(int CustomerId)
        {
            Customer cs = new Customer();
            cs.CustomerID = CustomerId;
            Customer search_book = cs.Search();
            return View(search_book);
        }

        public ActionResult Reporting()
        {
            LocalReport lr = new LocalReport();
            lr.ReportPath = Server.MapPath("~/Report/CustomerReport.rdlc");
            ReportDataSource rd = new ReportDataSource("DataSet1",new Customer().ShowAll());
            lr.DataSources.Add(rd);
            byte[] render = lr.Render("PDF");
            return File(render, "application/pdf");

        }
    }
}
