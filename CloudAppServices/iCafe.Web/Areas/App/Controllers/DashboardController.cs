﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iCafe.Web.Areas.App.Controllers
{
    public class DashboardController : Controller
    {
        //
        // GET: /App/Dashboard/

        public ActionResult Index()
        {
            return View();
        }

    }
}
