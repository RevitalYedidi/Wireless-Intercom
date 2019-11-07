using NEW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NEW.Controllers
{
    public class TenantsController : BaseController
    {
        private ApplicationDbContext _context;

        public TenantsController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Tenant_Area()
        {
            if (LoginSession != "")
            {
                var Tenant = _context.Tenants.FirstOrDefault(i => i.UserEmail == LoginSession.ToString());
                ViewBag.TenantData = Tenant;
                ViewBag.userMail = LoginSession;
                ViewBag.IsAdmin = Tenant.Admin.ToString();
                ViewBag.FirstName = Tenant.FirstName.ToString();
                return View(Tenant);
            }

            //routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");

            return  RedirectToAction("Login", "Home");

        }


        public ActionResult Tenants_List()
        {
            IsApprove = "";
            var Tenants = _context.Tenants.Where(i => i.BuildingId == 1).ToList();
            //var TenantsFromBuikding = 
            ViewBag.approve = IsApprove;
            return View(Tenants);
            
        }
        public JsonResult CheckSessionApprove()
        {
            return Json(IsApprove);
        }
        [HttpPost]
        public JsonResult SaveDetails(string FirstName, string LastName, string Id)
        {
            try
            {
                using (ApplicationDbContext context = new ApplicationDbContext())
                {
                    var Tenant = context.Tenants.FirstOrDefault(t => t.Id.ToString() == Id);

                    Tenant.FirstName = FirstName;
                    Tenant.LastName = LastName;

                    context.SaveChanges();

                    return Json("Details Succesfuly Saved!");
                };
            }
            catch(Exception e )
            {
                return Json("  There Was A Problem " + e.Message);
            }
        }
        [HttpPost]
        public JsonResult ChangePassword(string OldPassword , string NewPassword, string Id)
        {
            try
            {
                using (ApplicationDbContext context = new ApplicationDbContext())
                {
                    var Tenant = context.Tenants.FirstOrDefault(t => t.Id.ToString() == Id);

                    if(Tenant.UserPassword != OldPassword)
                    {
                        return Json("Wrong Password");
                    }
                    else
                    {
                        Tenant.UserPassword = NewPassword;

                        context.SaveChanges();
                        return Json("Details Succesfuly Saved!");
                    }

                };
            }
            catch (Exception e)
            {
                return Json("  There Was A Problem " + e.Message);
            }

        }
        [HttpPost]
        public JsonResult SaveEntry(string msg, int buildingId, int TenantId)
        {
            try
            {
                Entrances entry = new Entrances();
                using (ApplicationDbContext context = new ApplicationDbContext())
                {
                    entry.Message = msg;
                    entry.BuildingId = buildingId;
                    entry.TenantId = TenantId;
                    entry.Date = DateTime.Now.ToString("dd/MM/yyyy");
                    entry.Time = DateTime.Now.ToString("HH:mm"); 

                    context.Entrances.Add(entry);
                    context.SaveChanges();

                    return Json("Details Succesfuly Saved!");
                };
            }
            catch (Exception e)
            {
                return Json("  There Was A Problem " + e.Message);
            }
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