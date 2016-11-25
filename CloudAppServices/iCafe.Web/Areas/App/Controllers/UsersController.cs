using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iCafe.Web.Areas.App.Controllers
{
    public class UsersController : Controller
    {
        //
        // GET: /App/Users/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Users()
        {
            return View();
        }

        public ActionResult Roles()
        {
            return View();
        }

    }
}
