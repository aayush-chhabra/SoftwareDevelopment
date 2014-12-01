using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Capstone.Models;
using System.Transactions;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using Capstone.Filters;

namespace Capstone.Controllers
{
    public class ProjectController : Controller
    {
        private CapstoneDb db = new CapstoneDb();

        //
        // GET: /Project/

        public ActionResult Index()
        {
            return View(db.Projects.ToList());
        }

        //
        // GET: /Project/Details/5

        public ActionResult Details(int id = 0)
        {
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        //
        // GET: /Project/Create
        [Authorize(Roles = "Administrator, Investigator")]
        public ActionResult Create()
        {
            if (Roles.GetRolesForUser().Contains("Administrator"))
            {
                PopulatePIsDropDownList();
            }
            else
            {
                List<SelectListItem> investigatorsQuery = new List<SelectListItem>();

                string _username = Membership.GetUser().UserName;
               
                var user = (from p in db.Users
                           where p.UserName.Equals(_username)
                           select p.Id).Take(1);

                var user1 = db.Users.Find((int)user.First());

                investigatorsQuery.Add(new SelectListItem { 
                Text =  user1.FullName,
                Value =  user1.Id.ToString() });

                ViewBag.UserId = investigatorsQuery;
            }
            return View();
        }

        //
        // POST: /Project/Create

        [HttpPost]
        [Authorize(Roles = "Administrator, Investigator")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Project project)
        {
            if (ModelState.IsValid)
            {
                project.User = db.Users.Find(project.UserId);
                db.Projects.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            PopulatePIsDropDownList(project.User);
            return View(project);
        }

        //
        // GET: /Project/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id = 0)
        {
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            PopulatePIsDropDownList();
            return View(project);
        }

        //
        // POST: /Project/Edit/5

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            PopulatePIsDropDownList(project.User);
            return View(project);
        }

        //
        // GET: /Project/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id = 0)
        {
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        //
        // POST: /Project/Delete/5

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Administrator")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Project project = db.Projects.Find(id);
            db.Projects.Remove(project);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Administrator")]
        private void PopulatePIsDropDownList(object selectedPIs = null)
        {   
            string roleName = "Investigator";
            var investigatorsList = Roles.GetUsersInRole(roleName);

            List<SelectListItem> investigatorsQuery = new List<SelectListItem>();

            foreach ( var investigator in investigatorsList) {
                var user = (from p in db.Users
                           where p.UserName.Equals(investigator)
                           select p.Id).Take(1);

                var user1 = db.Users.Find((int)user.First());

                investigatorsQuery.Add(new SelectListItem { 
                Text =  user1.FullName,
                Value =  user1.Id.ToString() });
            }

            ViewBag.UserId = investigatorsQuery;//new SelectList(investigatorsQuery, "Id", "FullName", selectedPIs);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}