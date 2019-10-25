using NEW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NEW.Controllers
{
    public class TenantsController : Controller
    {

        private ApplicationDbContext _context;

        public TenantsController()
        {
            _context = new ApplicationDbContext();
          
        }
        public ActionResult Tenant_Area()
        {
            return View();
        }


        public ActionResult Tenants_List()
        {
           
            var Tenants = _context.Tenants.Where(i => i.BuildingId == 1).ToList();
            //var TenantsFromBuikding = 
            return View(Tenants);
        }

        [HttpPost]
        public JsonResult SaveNotify(string msg, string userId)
        {

            return Json(true);
        }
    }
}