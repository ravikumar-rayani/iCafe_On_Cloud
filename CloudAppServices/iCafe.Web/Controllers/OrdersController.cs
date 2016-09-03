using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iCafe.Web.Controllers
{
    public class OrdersController : BaseController
    {
        //
        // GET: /Orders/
        public ActionResult Index()
        {
            return View();
        }
	}
}