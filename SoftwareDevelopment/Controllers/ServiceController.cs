using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Models;

namespace Capstone.Controllers
{
    public class ServiceController : Controller
    {
        private CapstoneDb db = new CapstoneDb();

        //
        // GET: /Service/

        public ActionResult Index()
        {
            return View(db.ServiceAreas.ToList());
        }

        //
        // GET: /Service/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Service/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ServiceArea servicearea)
        {
            if (ModelState.IsValid)
            {
                db.ServiceAreas.Add(servicearea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(servicearea);
        }

        //
        // GET: /Service/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ServiceArea servicearea = db.ServiceAreas.Find(id);
            if (servicearea == null)
            {
                return HttpNotFound();
            }
            return View(servicearea);
        }

        //
        // POST: /Service/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ServiceArea servicearea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servicearea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(servicearea);
        }

        //
        // GET: /Service/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ServiceArea servicearea = db.ServiceAreas.Find(id);
            if (servicearea == null)
            {
                return HttpNotFound();
            }
            return View(servicearea);
        }

        //
        // POST: /Service/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServiceArea servicearea = db.ServiceAreas.Find(id);
            db.ServiceAreas.Remove(servicearea);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}