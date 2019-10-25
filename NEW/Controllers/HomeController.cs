using NEW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NEW.Controllers
{
    public class HomeController : Controller
    {

        private ApplicationDbContext _context;
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

      
        /// <summary>
        ///יקבל מזהה של בניין וכך יזהה את הקוד ואת כל מה שצריך
        /// </summary>
        /// <returns></returns>
        public ActionResult Admin()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var building = context.Buildings.FirstOrDefault(b => b.Id == 1);

                return View(building);
            };
        }

        public JsonResult ChangeCode(string BuildingID)
        {
            return Json(true);
        }

        //בעתיד להוסיף": לשלוח לפונקציה גם מספק בניין לדעת איזה קוד של בניין אנחנו בודקים
        //כרגע זה רק על בניין מספר 1
       
        public JsonResult CheckCode(string InsertedCode)
        {
            string code = InsertedCode.Replace(",", "");

            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var TheCode = context.Buildings.FirstOrDefault(b => b.Id == 1).CyferCode;

                if (code == TheCode.ToString())
                {
                    return Json("Confirmed");
                }
                else
                {
                    return Json("Not Confirmed");
                }
            };
        }

    }
}