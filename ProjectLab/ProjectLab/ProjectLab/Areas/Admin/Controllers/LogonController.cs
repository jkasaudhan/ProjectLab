using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectLab.Helpers;
using ProjectLab.Areas.Admin.Models.Logon;

namespace ProjectLab.Areas.Admin.Controllers
{
    public class LogonController : Controller
    {
        ProjectLab.Areas.Admin.Models.member.Model model = new ProjectLab.Areas.Admin.Models.member.Model();
        ProjectLab.Areas.Admin.Models.Logon.Model logonModel = new ProjectLab.Areas.Admin.Models.Logon.Model();
        //
        // GET: /Admin/Logon/

        public ActionResult Index()
        {
            ProjectLab.Areas.Admin.Models.member.Member membr = new ProjectLab.Areas.Admin.Models.member.Member();
            return View("AdminLogon");
        }

        //
        // GET: /Admin/Logon/Details/5
        

       

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Admin/Logon/Create
        
        public ActionResult Logon()//doing this we call the view by default to call its function logon,which is also called by default..
        {
            ProjectLab.Areas.Admin.Models.Logon.Model logonModel = new ProjectLab.Areas.Admin.Models.Logon.Model();
            return View("AdminLogon");
        } 

        //
        // POST: /Admin/Logon/Create

        [HttpPost]
        public ActionResult Logon(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here string.Compare(str1, str2);


                Admin.Models.member.Member mem = new Admin.Models.member.Member();
                var memberList = new List<Admin.Models.member.Member>();
                
                if (ValidateUser(collection.Get("Username"), collection.Get("Password")))
                {

                    var memid= model.GetMemberIDFromUsername(collection.Get("Username"));
                    Session["SelectedMemberID"] = memid.MemberID;
                   var roleid = model.GetRoleIDByMemberID(Int32.Parse(Session["SelectedMemberID"].ToString()));
                    Session["roleID"] = roleid.RoleID;
                    return RedirectToAction("../Index");
                }
                else 
               {
                 return RedirectToAction("Logon");
               }
            }
           
            catch
            {
                return View();
            }
        }
        
     
        
        public bool ValidateUser(string username, string password)
        {
            var encryptedPassword = logonModel.GetEncryptedPassword(username);
            var passwordToCheck = Encryptor.MD5Hash(password);
            if (passwordToCheck.Equals(encryptedPassword))
            {
                return true;
            }
            else
            {
                return false;
            }
        }























        //
        // GET: /Admin/Logon/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Admin/Logon/Edit/5

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
        // GET: /Admin/Logon/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Admin/Logon/Delete/5

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
