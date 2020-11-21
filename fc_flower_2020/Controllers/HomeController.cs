using DataAccess;
using MyDataBase;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace fc_flower_2020.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {  
            return View();
        }
        public ActionResult AboutUs()
        {
            return View();
        }
    }
}