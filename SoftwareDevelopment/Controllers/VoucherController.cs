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
    public class VoucherController : Controller
    {
        private CapstoneDb db = new CapstoneDb();

        //
        // GET: /Voucher/

        public ActionResult Index()
        {
            return View(db.Vouchers.ToList());
        }

        //
        // GET: /Voucher/Details/5

        public ActionResult Details(int id = 0)
        {
            Voucher voucher = db.Vouchers.Find(id);
            if (voucher == null)
            {
                return HttpNotFound();
            }
            return View(voucher);
        }

        //
        // GET: /Voucher/Create
        [Authorize(Roles = "Administrator, Conduits Administrator")]
        public ActionResult Create()
        {
            PopulateProjectsDropDownList();
            PopulateDetailedServicesDropDownList();
            return View();
        }

        //
        // POST: /Voucher/Create
        [Authorize(Roles = "Administrator, Conduits Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Voucher voucher)
        {
            if (ModelState.IsValid)
            {
                voucher.Project = db.Projects.Find(voucher.ProjectId);
                voucher.DetailedService = db.DetailedServices.Find(voucher.DetailedServiceId);

                db.Vouchers.Add(voucher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            PopulateProjectsDropDownList(voucher.Project);
            PopulateDetailedServicesDropDownList(voucher.DetailedService);
            return View(voucher);
        }

        //
        // GET: /Voucher/Edit/5
        [Authorize(Roles = "Administrator, Conduits Administrator")]
        public ActionResult Edit(int id = 0)
        {
            Voucher voucher = db.Vouchers.Find(id);
            if (voucher == null)
            {
                return HttpNotFound();
            }
            //PopulateProjectsDropDownList();
            return View(voucher);
        }

        //
        // POST: /Voucher/Edit/5

        [HttpPost]
        [Authorize(Roles = "Administrator, Conduits Administrator")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Voucher voucher)
        {
            if (ModelState.IsValid)
            {
                //voucher.Project = db.Projects.Find(voucher.ProjectId);
                db.Entry(voucher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //PopulateProjectsDropDownList(voucher.Project);
            return View(voucher);
        }

        //
        // GET: /Voucher/Delete/5
        [Authorize(Roles = "Administrator, Conduits Administrator")]
        public ActionResult Delete(int id = 0)
        {
            Voucher voucher = db.Vouchers.Find(id);
            if (voucher == null)
            {
                return HttpNotFound();
            }
            return View(voucher);
        }

        //
        // POST: /Voucher/Delete/5
        [Authorize(Roles = "Administrator, Conduits Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Voucher voucher = db.Vouchers.Find(id);
            db.Vouchers.Remove(voucher);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private void PopulateProjectsDropDownList(object selectedProjects = null)
        {
            var projectsQuery = from p in db.Projects
                                where p.Status == ProjectStatus.approved
                             orderby p.Name
                             select p;
            ViewBag.ProjectId = new SelectList(projectsQuery, "Id", "Name", selectedProjects);
        }

        private void PopulateDetailedServicesDropDownList(object selectedServices = null)
        {
            var servicesQuery = from p in db.DetailedServices
                                orderby p.Name
                                select p;
            ViewBag.DetailedServiceId = new SelectList(servicesQuery, "Id", "Name", selectedServices);
        }

        private void RemainingQuantity()
        {
            var vouchersQuery = from v in db.Vouchers
                                where v.Status == Status.Active
                                join ve in db.VoucherEvents on v.Id equals ve.VoucherId
                                select new { v, ve };
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}