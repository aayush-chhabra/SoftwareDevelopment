using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Capstone.Controllers
{
    public class HomeController : Controller
    {
        CapstoneDb _db = new CapstoneDb();

        public ActionResult Index()
        {
            if (Roles.GetRolesForUser().Contains("Administrator"))
            {
                var projectsQuery = from v in _db.Projects
                                    where !(v.Status.Equals("approved"))
                                    select v;
                return View(_db.Projects.ToList());
            }

            return View(_db.Projects.ToList());
        }

        private int getCurrentUserId()
        {
            MembershipUser user = Membership.GetUser(User.Identity.Name);

            if (user == null)
            {
                return 0;
            }
            return (int)user.ProviderUserKey;
        }

        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
