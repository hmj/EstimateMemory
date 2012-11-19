using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SekisanTeam.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Detail()
        {
            ViewBag.Message = "見積詳細";
            return View();
        }

        public ActionResult Index()
        {
            ViewBag.Message = "ASP.NET MVC へようこそ";
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
