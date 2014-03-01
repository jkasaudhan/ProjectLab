using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectLab.Areas;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using ProjectLab.Helpers;
//using Telerik.Web.UI;
namespace ProjectLab.Areas.Admin.Controllers
{
    public class memberController : Controller
    {
        ProjectLab.Areas.Admin.Models.member.Model model = new ProjectLab.Areas.Admin.Models.member.Model();
       
        // GET: /Admin/member/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }

      
       
       public ActionResult Image()
       {
           return View();
       }
   
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Admin.Models.member.Member mem = new Admin.Models.member.Member();
                var memberList = new List<Admin.Models.member.Member>() ;
                var encPassword = Encryptor.MD5Hash(collection.Get("Password"));
                //int roleid = Int32.Parse(collection.Get("RoleID").ToString());
                int roleid = 1;
                model.Createmember(collection.Get("FirstName"), collection.Get("LastName"), collection.Get("Email"), collection.Get("Username"), encPassword,roleid);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Edit(int id)
        {
            ProjectLab.Areas.Admin.Models.member.Member proj = model.GetData(id);
           // proj = model.GetData(id);
            return View("Edit", proj);
        }

       
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                model.Edit(id,collection.Get("FirstName"),collection.Get("LastName"),collection.Get("Email"), collection.Get("Username"),collection.Get("Password"));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        /// <summary>
        /// //details

        public ActionResult Details(int id)
        {
            ProjectLab.Areas.Admin.Models.member.Member pro = new ProjectLab.Areas.Admin.Models.member.Member();
            pro = model.Details(id);
            return View("Details",pro);
        }

        
         [HttpPost]
        public ActionResult Details(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                model.Details(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    


        //
        // GET: /Admin/Project/Delete/5

        public ActionResult Delete(int id)
        {
            ProjectLab.Areas.Admin.Models.member.Member proj = new ProjectLab.Areas.Admin.Models.member.Member();
               
            return View("Delete");
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

    }
       //////////////////////////////////////////////////////

    //[HttpPost]
    //   public ActionResult Image(HttpPostedFileBase file)
    //   {
    //       string path = System.IO.Path.Combine(Server.MapPath("~/Images"), System.IO.Path.GetFileName(file.FileName));
    //       file.SaveAs(path);
    //       ViewBag.Message = "File uploaded successfully";
    //       return View();
    //   }

        //public ActionResult ThumbImage(int id, int width, int height)
        //{
        //    var d = _rDocument.GetById(id);
        //    Image i = null;
        //    try
        //    {
        //        i = Image.FromFile(d.PhysicalFilename);
        //        return new ProjectLab.Areas.Admin.Models.member.ImageResult(i, width, height);
        //    }
        //    catch (Exception ex)
        //    {
        //        i = new Bitmap(1, 1);
        //        return new ProjectLab.Areas.Admin.Models.member.ImageResult(i, 1, 1);
        //    }
        //    finally
        //    {
        //        if (i != null) i.Dispose();
        //    }
        //}




        ////////////////////////////////////////////////////
       
    
}
