using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ProjectLab.Helpers;

namespace ProjectLab.Areas.Admin.Controllers
{
    public class SignupController : Controller
    {

        ProjectLab.Areas.Admin.Models.member.Model model = new ProjectLab.Areas.Admin.Models.member.Model();
        ProjectLab.Areas.Admin.Models.Signup.Model signupmodel = new ProjectLab.Areas.Admin.Models.Signup.Model();

        public ActionResult Index()
        {
            // ProjectLab.Areas.Admin.Models.member.Member membr = new ProjectLab.Areas.Admin.Models.member.Member();
            return View("SignUpForm");
        }

        //

        // GET: /Admin/Signup/Create

        public ActionResult Signup()
        {
            return View("MemberSignUp");
        }

        //
        // POST: /Admin/Signup/Create

        [HttpPost]
        public ActionResult Signup(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here string.Compare(str1, str2);
                Admin.Models.member.Member roleobject = new Admin.Models.member.Member();
                Admin.Models.member.Member memobject = new Admin.Models.member.Member();
               // var memList = new List<Admin.Models.member.Member>();
                var encPassword = Encryptor.MD5Hash(collection.Get("Password"));
                var role = collection.Get("names");
                model.Createmember(collection.Get("FirstName"), collection.Get("LastName"), collection.Get("Email"), collection.Get("Username"), encPassword, Int32.Parse(role));
                 memobject = model.GetMemberIDFromUsername(collection.Get("Username"));
                Session["SelectedMemberID"] = memobject.MemberID;
                roleobject = model.GetRoleIDByMemberID(memobject.MemberID);
                Session["RoleID"] = roleobject.RoleID;
               // return RedirectToAction("Logon", "Logon");
                //return View("Index");
                return RedirectToAction("../Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
