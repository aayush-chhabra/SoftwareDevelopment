using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Capstone.Models;

namespace Capstone.Controllers
{
    public class DetailedServiceController : Controller
    {
        private CapstoneDb db = new CapstoneDb();
        public static int _serviceArea = 0;

        //
        // GET: /DetailedService/

        public ActionResult Index([Bind(Prefix="id")] int serviceAreaId)
        {
            var serviceArea = db.ServiceAreas.Find(serviceAreaId);
            if (serviceArea != null)
            {
                _serviceArea = serviceAreaId;
                return View(serviceArea);
            }
            return HttpNotFound();
        }

        //
        // GET: /DetailedService/Details/5

        public ActionResult Details(int id = 0)
        {
            DetailedService detailedservice = db.DetailedServices.Find(id);
            if (detailedservice == null)
            {
                return HttpNotFound();
            }
            return View(detailedservice);
        }

        //
        // GET: /DetailedService/Create

        [HttpGet]
        public ActionResult Create(int serviceAreaId)
        {
            PopulateServiceProvidersDropDownList();
            return View();
        }

        //
        // POST: /DetailedService/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DetailedService detailedservice)
        {
            if (ModelState.IsValid)
            {
                var serviceArea = db.ServiceAreas.Find(_serviceArea);
                detailedservice.ServiceArea = serviceArea;

                detailedservice.ServiceProvider = db.Users.Find(detailedservice.UserId);
                
                db.DetailedServices.Add(detailedservice);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = _serviceArea });
            }

            return View(detailedservice);
        }

        //
        // GET: /DetailedService/Edit/5

        public ActionResult Edit(int id = 0)
        {
            DetailedService detailedservice = db.DetailedServices.Find(id);
            if (detailedservice == null)
            {
                return HttpNotFound();
            }
            return View(detailedservice);
        }

        //
        // POST: /DetailedService/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DetailedService detailedservice)
        {
            if (ModelState.IsValid)
            {
                var serviceArea = db.ServiceAreas.Find(_serviceArea);
                detailedservice.ServiceArea = serviceArea;

                db.Entry(detailedservice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = _serviceArea });
            }
            return View(detailedservice);
        }

        //
        // GET: /DetailedService/Delete/5

        public ActionResult Delete(int id = 0)
        {
            DetailedService detailedservice = db.DetailedServices.Find(id);
            if (detailedservice == null)
            {
                return HttpNotFound();
            }
            return View(detailedservice);
        }

        //
        // POST: /DetailedService/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetailedService detailedservice = db.DetailedServices.Find(id);
            db.DetailedServices.Remove(detailedservice);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = _serviceArea });
        }

        [Authorize(Roles = "Administrator")]
        private void PopulateServiceProvidersDropDownList(object selectedProviders = null)
        {
            string roleName = "Service Provider";
            var serviceProviderList = Roles.GetUsersInRole(roleName);

            List<SelectListItem> servicesQuery = new List<SelectListItem>();

            foreach (var investigator in serviceProviderList)
            {
                var user = (from p in db.Users
                            where p.UserName.Equals(investigator)
                            select p.Id).Take(1);

                var user1 = db.Users.Find((int)user.First());

                servicesQuery.Add(new SelectListItem
                {
                    Text = user1.FullName,
                    Value = user1.Id.ToString()
                });
            }

            ViewBag.UserId = servicesQuery; // new SelectList(servicesQuery, "Id", "FullName", selectedProviders);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}