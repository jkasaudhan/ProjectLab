using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApplicationClient.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        ApplicationClient.ProjectLabLogin.LoginClient wb = new ApplicationClient.ProjectLabLogin.LoginClient();
        public ActionResult Index()
        {
            ViewData["Message"] = "Project Management Tools!";
            ViewData["M1"] = wb.DoWork();
            ViewData["M2"] = wb.CreateCompany();
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
