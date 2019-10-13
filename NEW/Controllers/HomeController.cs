using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NEW.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Main()
        {
            return View();
        }

        public ActionResult Message()
        {
            return View();
        }

        public ActionResult Entrance()
        {
            return View();
        }


        

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Tenant_Area()
        {
            return View();
        }

        public ActionResult Admin()
        {
            return View();
        }
    }
}