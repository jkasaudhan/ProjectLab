using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectLab.Areas.Admin.AdminShared
{
    public class AdminSharedController : Controller
    {
        //
        // GET: /Shared/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Menu()
        {

            return PartialView("Menu");
        }

        public ActionResult Header()
        {
            return PartialView("Header");
        }

        public ActionResult Slider()
        {
            return PartialView("Slider");
        }

        public ActionResult Proposals()
        {
            return PartialView("Proposals");
        }

        public ActionResult Search()
        {
            return PartialView("Search");
        }

        public ActionResult Mortgages()
        {
            return PartialView("Mortgages");
        }

        public ActionResult Subscribe()
        {
            return PartialView("Subscribe");
        }

        public ActionResult Footer()
        {
            return PartialView("Footer");
        }
    }
}
