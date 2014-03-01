using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ProjectLab.Areas.Admin.Controllers
{
    public class IndexController : Controller
    {
        //
        // GET: /Admin/Dummy/
        ProjectLab.Areas.Admin.Models.Events.Model model = new ProjectLab.Areas.Admin.Models.Events.Model();

        public ActionResult Index()
        {
            //var eventat = model.EventDate;
            //var dte = collection.Get("date1").ToString();
            //if (dte == eventat.ToString())
            //{
            //    var desc = model.EventTitle;
            //    string msg = desc;
                 
            //    return Json(msg, JsonRequestBehaviour.AllowGet);

            //    // System.Windows.Forms.MessageBox.Show(desc);
            //}
           return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        //
        // GET: /Admin/Dummy/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Admin/Dummy/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Dummy/Create

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
        // GET: /Admin/Dummy/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Admin/Dummy/Edit/5

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
        // GET: /Admin/Dummy/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Admin/Dummy/Delete/5

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
