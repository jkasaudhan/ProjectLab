using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data;

namespace ProjectLab.Areas.Admin.Controllers
{
    public class ReportController : Controller
    {
        ProjectLab.Areas.Admin.Models.Report.Model reportModel = new ProjectLab.Areas.Admin.Models.Report.Model();
        //
        // GET: /Admin/Report/

        public ActionResult Index()
        {
           // ReportDocument rptDoc = new ReportDocument();
           // DataSet ds = new DataSet();
           // DataTable dt = new DataTable();
           // dt.TableName = "Crystal Report Example";
           // ds = reportModel.GetEmployeeDetails();
           // // rptDoc.Load(@"E:/reports/SimpleCrystal.rpt");
           //// rptDoc.Load(@Server.MapPath("SimpleCrystal.rpt"));
           // var sd=@"E:/reports/SimpleCrystal.rpt";

           // rptDoc.Load(sd);
           // rptDoc.SetDataSource(ds);
           // CrystalDecisions.Web.CrystalReportViewer reportViewer = new CrystalDecisions.Web.CrystalReportViewer();
           // reportViewer.ReportSource = rptDoc;

            return View("Test");
        }

        //
        // GET: /Admin/Report/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Admin/Report/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Admin/Report/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Admin/Report/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Admin/Report/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/Report/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Admin/Report/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
