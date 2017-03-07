using Alga.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Alga.Controllers.Web
{
    public class RolesController : Controller
    {
        private AlgaContext db = new AlgaContext();
        private ApplicationDbContext _context = new ApplicationDbContext();



        public ActionResult Index()
        {
            var roles = _context.Roles.ToList();
            return View(roles);
        }




        // GET: /Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Roles/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                _context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole() { Name = collection["RoleName"] });
                _context.SaveChanges();
                ViewBag.ResultMessage = "Role created successfully !";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Roles/Edit/5
        public ActionResult Edit(string roleName)
        {
            var thisRole = _context.Roles.Where(r => r.Name.Equals(roleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            return View(thisRole);
        }

        //
        // POST: /Roles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Microsoft.AspNet.Identity.EntityFramework.IdentityRole role)
        {
            try
            {
                _context.Entry(role).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Delete(string roleName)
        {
            var thisRole = _context.Roles.Where(r => r.Name.Equals(roleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            _context.Roles.Remove(thisRole);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ManageUserRoles()
        {
            // prepopulate roles and usernames for the view dropdown
            var list = _context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = list;

            var userNames =
                _context.Users.OrderBy(u => u.UserName)
                    .ToList()
                    .Select(uu => new SelectListItem { Value = uu.UserName.ToString(), Text = uu.UserName })
                    .ToList();
            ViewBag.UserNames = userNames;

            return View();

            //var pavardes = db.Asmuos.OrderBy(n => n.Pavarde).ToList().Select(nn => new SelectListItem { Value = nn.Pavarde.ToString(), Text = nn.Pavarde }).ToList();
            //ViewBag.Pavardes = pavardes;



        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RoleAddToUser(string UserName, string RoleName)
        {
            ApplicationUser user = _context.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            UserManager<ApplicationUser> account = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            account.AddToRole(user.Id, RoleName);

            //var account = new AccountController();
            //account.UserManager.AddToRole(user.Id, RoleName);

            ViewBag.ResultMessage = "Role created successfully !";

            // prepopulat roles for the view dropdown
            var list = _context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = list;

            var userNames =
                _context.Users.OrderBy(u => u.UserName)
                    .ToList()
                    .Select(uu => new SelectListItem { Value = uu.UserName.ToString(), Text = uu.UserName })
                    .ToList();
            ViewBag.UserNames = userNames;

            return View("ManageUserRoles");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetRoles(string UserName)
        {
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                ApplicationUser user = _context.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                UserManager<ApplicationUser> _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                ViewBag.RolesForThisUser = _userManager.GetRoles(user.Id);

                //var account = new AccountController();
                //ViewBag.RolesForThisUser = account.UserManager.GetRoles(user.Id);
            }

            // prepopulat roles for the view dropdown
            var list = _context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = list;

            var userNames =
                _context.Users.OrderBy(u => u.UserName)
                    .ToList()
                    .Select(uu => new SelectListItem { Value = uu.UserName.ToString(), Text = uu.UserName })
                    .ToList();
            ViewBag.UserNames = userNames;

            return View("ManageUserRoles");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRoleForUser(string UserName, string RoleName)
        {
            //var account = new AccountController();

            UserManager<ApplicationUser> account = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

            ApplicationUser user = _context.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            if (account.IsInRole(user.Id, RoleName))
            {
                account.RemoveFromRole(user.Id, RoleName);
                ViewBag.ResultMessage = "Role removed from this user successfully !";
            }
            else
            {
                ViewBag.ResultMessage = "This user doesn't belong to selected role.";
            }
            // prepopulat roles for the view dropdown
            var list = _context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = list;

            var userNames =
                _context.Users.OrderBy(u => u.UserName)
                    .ToList()
                    .Select(uu => new SelectListItem { Value = uu.UserName.ToString(), Text = uu.UserName })
                    .ToList();
            ViewBag.UserNames = userNames;

            return View("ManageUserRoles");
        }


    }
}