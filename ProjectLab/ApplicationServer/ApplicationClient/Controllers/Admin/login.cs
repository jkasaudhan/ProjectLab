using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApplicationClient.Controllers.Admin
{
    public class login : Controller
    {
        //
        // GET: /Admin/
        ApplicationClient.Models.Admin.login model = new ApplicationClient.Models.Admin.login();
        public login()
        {

        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
