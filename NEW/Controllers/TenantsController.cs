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
        public JsonResult SaveNotify(int tenantId, string msg, string imgGuest)
        {
            Notifications notify = new Notifications();
            try
            {
                using (ApplicationDbContext context = new ApplicationDbContext())
                {
                    notify.TenantId = tenantId;
                    notify.GuestMessage = msg;
                    notify.ImgUrl = imgGuest;
                    notify.IsOpen = false;

                    context.Notifications.Add(notify);

                    context.SaveChanges();
                };
                return Json(notify.id);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return Json(-1);
            }
        }
    }
}