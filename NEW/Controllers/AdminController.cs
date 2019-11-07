using NEW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NEW.Controllers
{
    public class AdminController : BaseController
    {
        private ApplicationDbContext _context;

        public AdminController()
        {
            _context = new ApplicationDbContext();

        }

        public ActionResult List_of_Entrances()
        {
            if (LoginSession != "")
            {
                using (ApplicationDbContext context = new ApplicationDbContext())
                {
                    var Tenant = context.Tenants.FirstOrDefault(t => t.UserEmail == LoginSession);
                    ViewBag.IsAdmin = Tenant.Admin;

                    var Entrances = _context.Entrances.Where(i => i.BuildingId == 1).ToList();
                    ViewBag.Entrances = Entrances;

                    return View(Entrances);
                };
            }
            return RedirectToAction("Login", "Home");
        }

        public ActionResult Add_and_Edit_Tenants()
        {
            if (LoginSession != "")
            {
                using (ApplicationDbContext context = new ApplicationDbContext())
                {
                    var Tenant = context.Tenants.FirstOrDefault(t => t.UserEmail == LoginSession);
                    ViewBag.IsAdmin = Tenant.Admin;

                    var Tenants = _context.Tenants.Where(i => i.BuildingId == 1).ToList();
                    ViewBag.Tenants = Tenants;

                    return View(Tenants);
                };
            }
            return RedirectToAction("Login", "Home");
        }

        [HttpPost]
        public JsonResult SaveDetails(int Id, string FirstName, string LastName, int ApartmentNum, string UserEmail, string UserPass)
        {
            try
            {
                using (ApplicationDbContext context = new ApplicationDbContext())
                {
                    var Tenant = context.Tenants.FirstOrDefault(t => t.Id == Id);

                    Tenant.FirstName = FirstName;
                    Tenant.LastName = LastName;
                    Tenant.ApartmentNumber = ApartmentNum;
                    Tenant.UserEmail = UserEmail;
                    if (UserPass != "")
                    {
                        Tenant.UserPassword = UserPass;
                    }

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
        public JsonResult AddTenant(string FirstName, string LastName, int ApartmentNum, string UserEmail, string UserPass)
        {
            Tenant NewTenant = new Tenant();
            try
            {
                using (ApplicationDbContext context = new ApplicationDbContext())
                {

                    NewTenant.FirstName = FirstName;
                    NewTenant.LastName = LastName;
                    NewTenant.ApartmentNumber = ApartmentNum;
                    NewTenant.UserEmail = UserEmail;
                    NewTenant.UserPassword = UserPass;
                    NewTenant.BuildingId = 1;

                    context.Tenants.Add(NewTenant);
                    context.SaveChanges();

                    return Json("Details Succesfuly Saved!");
                };
            }
            catch (Exception e)
            {
                return Json("  There Was A Problem " + e.Message);
            }
        }
        

    }
}