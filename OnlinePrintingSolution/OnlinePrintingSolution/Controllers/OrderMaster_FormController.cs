using Microsoft.Reporting.WebForms;
using OnlinePrintingSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlinePrintingSolution.Controllers
{
    public class OrderMaster_FormController : Controller
    {
        //
        // GET: /Delivery_Form/

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(OrderMaster Om)
        {
            Om.Add();
            return View();
        }

        [HttpGet]
        public ActionResult ShowAll()
        {

            return View(new OrderMaster().ShowAll());
        }



        [HttpGet]
        public ActionResult Update(int OrderId)
        {
            OrderMaster Om = new OrderMaster();
            Om.OrderId = OrderId;
           OrderMaster search_book = Om.Search();
            return View(search_book);
        }
        [HttpPost]
        public ActionResult Update(OrderMaster Om)
        {
           Om.Update();
            return RedirectToAction("ShowAll");
        }


        [HttpGet]
        public ActionResult Delete(int OrderId)
        {
            OrderMaster Om = new OrderMaster();
           Om.OrderId= OrderId;
            Om.Delete();
            return RedirectToAction("ShowAll");
        }
        [HttpGet]
        public ActionResult Details(int OrderId)
        {
            OrderMaster Om = new OrderMaster();
            Om.OrderId = OrderId;
            OrderMaster search_book = Om.Search();
            return View(search_book);
        }

        public ActionResult Reporting()
        {
            LocalReport lr = new LocalReport();
            lr.ReportPath = Server.MapPath("~/Report/OrderMasterReport.rdlc");
            ReportDataSource rd = new ReportDataSource("DataSet1", new OrderMaster().ShowAll());
            lr.DataSources.Add(rd);
            byte[] render = lr.Render("PDF");
            return File(render, "application/pdf");

        }
    }
}
