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
    public class VoucherEventController : Controller
    {
        private CapstoneDb db = new CapstoneDb();

        //
        // GET: /VoucherEvent/

        public ActionResult Index()
        {
            return View(db.VoucherEvents.ToList());
        }

        //
        // GET: /VoucherEvent/Details/5

        public ActionResult Details(int id = 0)
        {
            VoucherEvent voucherevent = db.VoucherEvents.Find(id);
            if (voucherevent == null)
            {
                return HttpNotFound();
            }
            return View(voucherevent);
        }

        //
        // GET: /VoucherEvent/Create
        [Authorize(Roles = "Administrator, Investigator, Service Provider")]
        public ActionResult Create()
        {
            PopulateVouchersDropDownList();
            return View();
        }

        //
        // POST: /VoucherEvent/Create

        [HttpPost]
        [Authorize(Roles = "Administrator, Investigator, Service Provider")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VoucherEvent voucherevent)
        {
            if (ModelState.IsValid)
            {
                voucherevent.Voucher = db.Vouchers.Find(voucherevent.VoucherId);
                db.VoucherEvents.Add(voucherevent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            PopulateVouchersDropDownList(voucherevent.Voucher);
            return View(voucherevent);
        }

        //
        // GET: /VoucherEvent/Edit/5

        public ActionResult Edit(int id = 0)
        {
            VoucherEvent voucherevent = db.VoucherEvents.Find(id);
            if (voucherevent == null)
            {
                return HttpNotFound();
            }
            return View(voucherevent);
        }

        //
        // POST: /VoucherEvent/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VoucherEvent voucherevent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(voucherevent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(voucherevent);
        }

        //
        // GET: /VoucherEvent/Delete/5

        public ActionResult Delete(int id = 0)
        {
            VoucherEvent voucherevent = db.VoucherEvents.Find(id);
            if (voucherevent == null)
            {
                return HttpNotFound();
            }
            return View(voucherevent);
        }

        //
        // POST: /VoucherEvent/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VoucherEvent voucherevent = db.VoucherEvents.Find(id);
            db.VoucherEvents.Remove(voucherevent);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private void PopulateVouchersDropDownList(object selectedVouchers = null)
        {
            if (User.IsInRole("Service Provider"))
            {
                var vouchersQuery = from v in db.Vouchers
                                    where (v.Status == Status.Active) && (v.DetailedService.ServiceProvider.UserName.Equals( User.Identity.Name))
                                    join ds in db.DetailedServices on v.DetailedServiceId equals ds.Id
                                    select new { v.Id, Name = "Project: " + v.Project.Name + " with Service: " + ds.Name };

                ViewBag.VoucherId = new SelectList(vouchersQuery, "Id", "Name", selectedVouchers);
            }
            else
            {
                var vouchersQuery = from v in db.Vouchers
                                    where v.Status == Status.Active
                                    join ds in db.DetailedServices on v.DetailedServiceId equals ds.Id
                                    select new { v.Id, Name = "Project: " + v.Project.Name + " with Service: " + ds.Name };

                ViewBag.VoucherId = new SelectList(vouchersQuery, "Id", "Name", selectedVouchers);
            }
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}