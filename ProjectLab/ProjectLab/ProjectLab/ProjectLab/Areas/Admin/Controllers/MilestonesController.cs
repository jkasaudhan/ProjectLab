using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectLab.Areas.Admin.Controllers
{
    public class MilestonesController : Controller
    {
        ProjectLab.Areas.Admin.Models.Milestones.Model model = new ProjectLab.Areas.Admin.Models.Milestones.Model();

        ProjectLab.Areas.Admin.Models.Project.Model Projectmodel = new ProjectLab.Areas.Admin.Models.Project.Model();

        // GET: /Admin/Milestones/

        public ActionResult Index(int id)
        {
            ViewData["ProjectID"] = id;/// either or OR 
            ViewData["DiscussionID"] = id;
            Session["SelectedProjectID"] = id;
            return View();
        }

        //
        // GET: /Admin/Milestones/Details/5




        //
        // GET: /Admin/Milestones/Create

        public ActionResult Create(int id)
        {
            Admin.Models.Milestones.Milestones data = new Admin.Models.Milestones.Milestones();
            Session["SelectedProjectID"] = id;
            ViewData["ProjectID"] = id;
            return View("Create");

        }

        //
        // POST: /Admin/Milestones/Create

        [HttpPost]
        public ActionResult Create(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Admin.Models.Milestones.Milestones mem = new Admin.Models.Milestones.Milestones();
                var milelist = new List<Admin.Models.Milestones.Milestones>();
               
                ViewData["ProjectID"] = id;
                string Deadline = collection.Get("date1");
                 var date = DateTime.Parse(Deadline);
                var selectedProjectID = Int32.Parse(Session["SelectedProjectID"].ToString());
                model.Createmilestones(selectedProjectID, collection.Get("MilestonesTitle"), collection.Get("MilestonesDescription"),collection.Get("Status"),date);
                Session["SelectedProjectID"] = id;
                return View("Index");
                
            }
            catch
            {
                return View();
            }
        }

       

        public ActionResult Details(int id)
        {
            ProjectLab.Areas.Admin.Models.Milestones.Milestones data = new ProjectLab.Areas.Admin.Models.Milestones.Milestones();
            var detailList = new List<Admin.Models.Milestones.Milestones>();
            // var proj = new Admin.Models.Project.Project();
            //  pList = Projectmodel.GetOnlyProjectTitle(id);
            detailList = model.GetOnlyMilestones(id);
            var proj = Projectmodel.GetProjectByMilestonesID(id);
            ViewData["ProjectID"] = proj.ProjectID;
            ViewData["MilestonesID"] = id;
            return View("Details");
        }

        [HttpPost]
        public ActionResult Details(int id, FormCollection collection)
        {

            try
            {
                // TODO: Add logic here
                Admin.Models.Milestones.Milestones proj = new Admin.Models.Milestones.Milestones();
                var dList = new List<Admin.Models.Milestones.Milestones>();

                var pList = new List<Admin.Models.Project.Project>();

                ViewData["MilestonesID"] = id;
                dList = model.GetOnlyMilestones(id);
                pList = Projectmodel.GetOnlyProjectTitle(id);
                return RedirectToAction("Details");

            }
            catch
            {
                return View();
            }
        }


        //
        // GET: /Admin/Milestones/Delete/5
    
        public ActionResult Delete(int id)
        {
            ProjectLab.Areas.Admin.Models.Milestones.Milestones mile = new Admin.Models.Milestones.Milestones();
           // model.DeleteSelectedMilestones(id);
            mile= model.GetData(id);
            ViewData["DiscussionID"] = id;
            return View("Delete",mile);
        }

        //
        // POST: /Admin/Project/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                ProjectLab.Areas.Admin.Models.Milestones.Milestones mile = new Admin.Models.Milestones.Milestones();
                model.DeleteSelectedMilestones(id);
                ViewData["DiscussionID"] = id;
                return View("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/Milestones/Edit/5

        public ActionResult Edit(int id)
        {
            ProjectLab.Areas.Admin.Models.Milestones.Milestones proj = new ProjectLab.Areas.Admin.Models.Milestones.Milestones();
            proj = model.GetData(id);
            return View("Edit", proj);
        }

        //
        // POST: /Admin/Project/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
               model.Edit(id, collection.Get("MilestonesTitle"), collection.Get("MilestonesDescription"),collection.Get("Status"),DateTime.Parse(collection.Get("Date1")));
                return View("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
