using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace ProjectLab.Areas.Admin.Controllers
{
    public class FileUploadController : Controller
    {
        //
        // GET: /AdAdmin/FileUpload/
        ProjectLab.Areas.Admin.Models.Project.Model projmodel= new ProjectLab.Areas.Admin.Models.Project.Model();

        public ActionResult FileUpload()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult FileUpload(HttpPostedFileBase uploadFile)
        {
            if (uploadFile.ContentLength > 0)
            {
                string filePath = Path.Combine(HttpContext.Server.MapPath("../Uploads"),
                Path.GetFileName(uploadFile.FileName));
                uploadFile.SaveAs(filePath);
            }
            return RedirectToAction("Index");
        }


    }
}
