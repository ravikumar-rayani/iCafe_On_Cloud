using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iCafe.Web.Areas.App.Controllers
{
    public class ConfigureController : Controller
    {
        //
        // GET: /App/Configure/

        public ActionResult Tables()
        {
            return View();
        }

        public ActionResult Devices()
        {
            return View();
        }

    }
}
