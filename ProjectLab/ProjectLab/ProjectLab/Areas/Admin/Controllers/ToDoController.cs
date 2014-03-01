using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectLab.Areas.Admin.Controllers
{
    public class ToDoController : Controller
    {
        //
        // GET: /Admin/ToDo/
        ProjectLab.Areas.Admin.Models.ToDo.Model model = new ProjectLab.Areas.Admin.Models.ToDo.Model();
        ProjectLab.Areas.Admin.Models.Project.Model projectmodel = new ProjectLab.Areas.Admin.Models.Project.Model();
        ProjectLab.Areas.Admin.Models.member.Model memModel = new ProjectLab.Areas.Admin.Models.member.Model();
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Admin/ToDo/Details/5



        //
        // GET: /Admin/ToDo/Create

        public ActionResult Create(int id)
        {
            ProjectLab.Areas.Admin.Models.ToDo.ToDo data = new ProjectLab.Areas.Admin.Models.ToDo.ToDo();
            var memList = new List<ProjectLab.Areas.Admin.Models.member.Member>();
            ViewData["ProjectID"] = id;
            Session["SelectedProjectID"] = id;

            var member = projectmodel.GetMembersByProjectID(id);
            //  string members = "3,5,7,8";
            var membs = member.ProjectMembers.Split(',');
            foreach (var itm in membs)
            {
                var mem = memModel.GetMemberByMemberID(Int32.Parse(itm));
                memList.Add(mem);

            }
            Session["SelectedMemberList"] = memList;
            Session["SelectedProjectID"] = id;
            return View("Create");

        }
        //
        // POST: /Admin/ToDo/Create

        [HttpPost]
        public ActionResult Create(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Admin.Models.ToDo.Model mem = new Admin.Models.ToDo.Model();
                var ToDolist = new List<Admin.Models.ToDo.ToDo>();
                Session["SelectedProjectID"] = id;
                ViewData["ProjectID"] = id;
                int members = Int32.Parse(collection.Get("members"));
                // var date = Convert.ToDateTime (collection.Get(Deadline));
                model.CreateToDo(id, collection.Get("ToDoTitle"), collection.Get("ToDoDescription"),members,collection.Get("Status"),DateTime.Parse(collection.Get("date1")));


                return View("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Details(int id)// it consists ToDo id
        {
            ProjectLab.Areas.Admin.Models.ToDo.ToDo data = new ProjectLab.Areas.Admin.Models.ToDo.ToDo();
            var dList = new List<Admin.Models.ToDo.ToDo>();

            dList = model.GetOnlyToDo(id);
            var proj = projectmodel.GetProjectByToDoID(id);
            ViewData["ProjectID"] = proj.ProjectID;
            Session["SelectedProjectID"] = proj.ProjectID;
            ViewData["ToDoID"] = id;
            return View("Details");
        }

        [HttpPost]
        public ActionResult Details(int id, FormCollection collection)
        {

            try
            {
                // TODO: Add logic here
                Admin.Models.ToDo.ToDo proj = new Admin.Models.ToDo.ToDo();
                var dList = new List<Admin.Models.ToDo.ToDo>();
                ViewData["ToDoID"] = id;
                dList = model.GetOnlyToDo(id);
                // pList = Projectmodel.GetOnlyProjectTitle(id);
                return RedirectToAction("Details");

            }
            catch
            {
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
            ProjectLab.Areas.Admin.Models.ToDo.ToDo to = new Admin.Models.ToDo.ToDo();
            // model.DeleteSelectedMilestones(id);
            to = model.GetData(id);
            ViewData["ToDoID"] = id;
            return View("Delete", to);
        }

        //
        // POST: /Admin/Project/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                ProjectLab.Areas.Admin.Models.ToDo.ToDo todo = new Admin.Models.ToDo.ToDo();
                model.DeleteSelectedToDo(id);
                ViewData["ToDoID"] = id;
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
            ProjectLab.Areas.Admin.Models.ToDo.ToDo proj = new ProjectLab.Areas.Admin.Models.ToDo.ToDo();
            proj = model.GetData(id);
            return View("Edit", proj);
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                //var dt = DateTime.Parse(collection.Get("Deadline"));
                 model.Edit(id, collection.Get("ToDoTitle"), collection.Get("ToDoDescription"),Int32.Parse(collection.Get(("AssignedTo").ToString())),collection.Get("Status"),DateTime.Parse(collection.Get("date1")));
                return View("Index");
            }
            catch
            {
                return View();
            }
        }
       
    }
}
