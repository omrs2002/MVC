using MVCCourse2017.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCourse2017.Controllers
{
    public class RolesController : Controller
    {
        private ApplicationDbContext _context;

        RolesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Roles
        public ActionResult Index()
        {
            var roles = _context.Roles.OrderBy(x => x.Name);
            return View(roles);
        }
    }
}