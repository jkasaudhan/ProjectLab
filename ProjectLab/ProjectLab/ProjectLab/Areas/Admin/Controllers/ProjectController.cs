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
    public class ProjectController : Controller
    {
        ProjectLab.Areas.Admin.Models.Project.Model model = new ProjectLab.Areas.Admin.Models.Project.Model();
        ProjectLab.Areas.Admin.Models.member.Model membermodel = new ProjectLab.Areas.Admin.Models.member.Model();
        ProjectLab.Areas.Admin.Models.Milestones.Model Milestonesmodel = new ProjectLab.Areas.Admin.Models.Milestones.Model();
        ProjectLab.Areas.Admin.Models.ToDo.Model todomodel = new ProjectLab.Areas.Admin.Models.ToDo.Model();
        // GET: /Admin/Project/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Admin/Project/Details/5



        //
        // GET: /Admin/Project/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Project/Create

        [HttpPost]

        public ActionResult Create(FormCollection collection)
        {
            try
            {

                Admin.Models.Project.Project proj = new Admin.Models.Project.Project();
                var projectList = new List<Admin.Models.Project.Project>();
                var mems = collection.Get("members");
                //    var file = collection.Get("");

                model.CreateProject(collection.Get("ProjectTitle"), collection.Get("ProjectDescription"), collection.Get("FirstName"), collection.Get("LastName"), Convert.ToString(mems));

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        //
        // GET: /Admin/Project/Edit/5

        public ActionResult Edit(int id)
        {
            ProjectLab.Areas.Admin.Models.Project.Project proj = new ProjectLab.Areas.Admin.Models.Project.Project();
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
                model.Edit(id, collection.Get("ProjectTitle"), collection.Get("ProjectDescription"), collection.Get("members"));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

      
        public ActionResult Details(int id)
        {
            ProjectLab.Areas.Admin.Models.Project.Project data = new ProjectLab.Areas.Admin.Models.Project.Project();
            Session["SelectedProjectID"] = id;
            data = model.Datadetails(id);
            return View("Details", data);


        }

        [HttpPost]
        public ActionResult Details(int pid, FormCollection collection)
        {

            try
            {
                // TODO: Add delete logic here
                Session["SelectedProjectID"] = pid;
                model.Details(pid);
                return RedirectToAction("Dicussion");

            }
            catch
            {
                return View();
            }
        }


      

        public ActionResult Delete(int id)
        {
            ProjectLab.Areas.Admin.Models.Project.Project proj = model.GetData(id);
            return View("Delete", proj);
        }

        //
        // POST: /Admin/Project/Delete/5

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
        //////////////////////////////////discussion here controller//////////////

        public ActionResult Discussion(int id)
        {
            ProjectLab.Areas.Admin.Models.Project.Project data = new ProjectLab.Areas.Admin.Models.Project.Project();
            data = model.Datadetails(id);

            ViewData["ProjectID"] = Session["SelectedProjectID"];
             var mid =Session["SelectedMemberID"];
            return View("CreateDiscussion",data);

        }

        [HttpPost]
        public ActionResult Discussion(int id, FormCollection collection)
        {

            try
            {

                Admin.Models.Project.Project proj = new Admin.Models.Project.Project();
                Admin.Models.Project.Project discuss = new Admin.Models.Project.Project();
                var discussList = new List<Admin.Models.Project.Project>();
                // var id = collection.Get("ProjectID");
                ViewData["ProjectID"] = id;
                proj = model.GetUsernameByMemberID(Int32.Parse(Session["SelectedMemberID"].ToString()));
                var mid = proj.UserName;
                var selectedProjectID = Int32.Parse(Session["SelectedProjectID"].ToString());
                model.CreateDiscussion(selectedProjectID, collection.Get("DiscussionTitle"), collection.Get("DiscussionDescription"),mid);
                discuss = model.GetDiscussionIdByProjectId(id);
                Session["SelectedDiscussionID"] = discuss.DiscussionID;
                 return View("Listed");


            }
            catch
            {
                return View();
            }
        }
        public ActionResult DiscussionList(int id)
        {
            ProjectLab.Areas.Admin.Models.Project.Project data = new ProjectLab.Areas.Admin.Models.Project.Project();
            var projectDiscList = new List<Admin.Models.Project.Project>();
           // projectDiscList = model.GetAllDiscussion(id);
            ViewData["ProjectID"] = Session["SelectedProjectID"];
            data = model.GetDiscussionIdByProjectId(id);
            Session["SelectedDiscussionID"] = data.DiscussionID;
            return View("Listed");
        }

        //////////////////////////////discussion end here /////////////////
        public ActionResult DeleteDiscussion(int id)
        {
            ProjectLab.Areas.Admin.Models.Project.Project proj = new ProjectLab.Areas.Admin.Models.Project.Project();
            Session["SelectedDiscussionID"] = id;
            return View("DelDiscussion");
        }

        //
        // POST: /Admin/Project/Delete/5

        [HttpPost]
        public ActionResult DeleteDiscussion(int id, FormCollection collection)
        {
            try
            {
                
                model.DelDiscussion(id);
               
              //  Session.Remove("SelectedDiscussionID");
              //  Session.Abandon();
                return View("Listed");
            }
            catch
            {
                return View();
            }
        }

        //////////////////////// comments here //////////////
        public ActionResult Comment(int id)
        {
           ProjectLab.Areas.Admin.Models.Project.Project data = new ProjectLab.Areas.Admin.Models.Project.Project();
           // var commList = new List<Admin.Models.Project.Peroject>();
            var disList = new List<Admin.Models.Project.Project>();
           ViewData["DiscussionID"] = Session["SelectedDiscussionID"];
           Session["SelectedDiscussionID"] = id;
            return View("CreateComments");
        }

        [HttpPost]
        public ActionResult Comment(int id, FormCollection collection)
        {
            try
            {
               // Admin.Models.Project.Project user = new Admin.Models.Project.Project();
                 Admin.Models.Project.Project proj = new Admin.Models.Project.Project();
                var CommentList = new List<Admin.Models.Project.Project>();
                proj=model.GetUsernameByMemberID(Int32.Parse(Session["SelectedMemberID"].ToString()));
                var name =proj.UserName;
               // model.GetAllComments(id);
               //user=model.GetUsernameByMemberID(proj.MemberID);
               // var name=user.UserName;
                var selectedDiscussionID = Int32.Parse(Session["SelectedDiscussionID"].ToString());
                model.CreateComments(selectedDiscussionID, collection.Get("Comments"),name);
                ViewData["DiscussionID"] = id;
                return View("CommentList");

            }
            catch
            {
                return View();
            }
        }
        public ActionResult ListComment(int id)
        {
            Admin.Models.Project.Project data = new Admin.Models.Project.Project();
            ViewData["DiscussionID"] = Session["SelectedDiscussionID"];
            return View("CommentList");
               
        }
    }
}
