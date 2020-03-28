using Microsoft.Reporting.WebForms;
using OnlinePrintingSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlinePrintingSolution.Controllers
{
    public class PrinterReg_FormController : Controller
    {
        //
        // GET: /PrinterReg_Form/

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(PrinterReg Pr)
        {
            Pr.Add();
            return View();
        }

        [HttpGet]
        public ActionResult ShowAll()
        {

            return View(new PrinterReg().ShowAll());
        }


        [HttpGet]
        public ActionResult Update(int printerId)
        {
            PrinterReg pr = new PrinterReg();
            pr.PrinterID = printerId;
            PrinterReg search_book = pr.Search();
            return View(search_book);
        }
        [HttpPost]
        public ActionResult Update(PrinterReg pr)
        {
            pr.Update();
            return RedirectToAction("ShowAll");
        }

        [HttpGet]
        public ActionResult Delete(int PrinterId)
        {
            PrinterReg pr= new PrinterReg();
            pr.PrinterID = PrinterId;
            pr.Delete();
            return RedirectToAction("ShowAll");
        }

        public ActionResult Reporting()
        {
            LocalReport lr = new LocalReport();
            lr.ReportPath = Server.MapPath("~/Report/PrinterReport.rdlc");
            ReportDataSource rd = new ReportDataSource("DataSet1", new PrinterReg().ShowAll());
            lr.DataSources.Add(rd);
            byte[] render = lr.Render("PDF");
            return File(render, "application/pdf");

        }

    }
}
