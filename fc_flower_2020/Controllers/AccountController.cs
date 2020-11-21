using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace fc_flower_2020.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Profile()
        {
            return View();
        }
        public ActionResult LoginOrRegister()
        {
            return View();
        }

    }
}