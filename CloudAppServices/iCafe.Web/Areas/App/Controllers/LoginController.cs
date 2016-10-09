using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iCafe.Web.Controllers;

namespace iCafe.Web.Areas.App.Controllers
{
    public class LoginController : BaseController
    {
        //
        // GET: /Login/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Test()
        {
            return View();
        }
	}
}