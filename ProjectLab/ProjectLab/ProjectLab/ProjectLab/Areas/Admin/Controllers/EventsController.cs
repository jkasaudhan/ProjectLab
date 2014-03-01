using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectLab.Areas;
using System.Web.UI.WebControls;
using System.IO;

namespace ProjectLab.Areas.Admin.Controllers
{
    public class EventsController : Controller
    {
        //
        // GET: /Admin/Events/
        ProjectLab.Areas.Admin.Models.Events.Model model = new ProjectLab.Areas.Admin.Models.Events.Model();

       
        public ActionResult  Index()
        {
           return View();
         }


        //
        // GET: /Admin/Events/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Admin/Events/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Admin.Models.Events.Events eve = new Admin.Models.Events.Events();
                var eventList = new List<Admin.Models.Events.Events>();
                var dte = (collection.Get("date1")).ToString();
               // dte=DateTime.Parse(HttpContext.IsPostNotification.Equals("CreatedAt").ToString());
                 var date2 = (DateTime.Parse(dte)).ToString("d");
                model.CreateEvent(collection.Get("EventTitle"), collection.Get("EventDescription"),date2);
            //    var today = DateTime.Today.ToShortDateString();
              //  var differnce = DateTime.Parse(dte).Subtract(DateTime.Parse(today));
               // ViewData["Timeleft"] = differnce;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Admin/Events/Edit/5

        public ActionResult Edit(int id)
        {
            ProjectLab.Areas.Admin.Models.Events.Events eve = new ProjectLab.Areas.Admin.Models.Events.Events();
            eve = model.GetData(id);
            return View("Edit", eve);
        }

        //
        // POST: /Admin/Project/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                model.Edit(id, collection.Get("EventTitle"), collection.Get("EventDescription"),(collection.Get("date1").ToString()));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        //
        // GET: /Admin/Events/Delete/5
 
        public ActionResult Delete(int id)
        {
            ProjectLab.Areas.Admin.Models.Events.Events eve = new ProjectLab.Areas.Admin.Models.Events.Events();
            eve=model.GetData(id);
            return View("Delete", eve);
        }

        //
        // POST: /Admin/Events/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                model.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        //
        // GET: /Admin/Events/Details/5
        public ActionResult Details(int id)
        {
            ProjectLab.Areas.Admin.Models.Events.Events eve = new ProjectLab.Areas.Admin.Models.Events.Events();
            eve= model.GetDetails(id);
            return View("Details", eve);
        }
        [HttpPost]
        public ActionResult Details(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                model.GetDetails(id);
                    
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
