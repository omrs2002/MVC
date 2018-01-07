using MVCCourse2017.Models;
using MVCCourse2017.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCourse2017.Controllers
{
    public class UsersController : Controller
    {
        private ApplicationDbContext _context;

        public UsersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Users
        public ActionResult Index()
        {
            IList<UsersVM> usersVM = new List<UsersVM>();
            var db = new ApplicationDbContext();
            var Users = db.Users.Include(u => u.Roles);

            var context = new ApplicationDbContext();
            var allUsers = context.Users.ToList();
            foreach (var item in allUsers)
            {
                usersVM.Add(
                    new UsersVM
                        {
                            DrivingLicense = item.DrivingLicense,
                            Email = item.Email,
                            Id = item.Id,
                            PhoneNumber = item.PhoneNumber,
                            UserName = item.UserName
                        }
                    );
            }
            return View(usersVM);
        }

        public ActionResult Edit(string id)
        {
            var xUsrs = _context.Users.SingleOrDefault(c => c.Id == id);
            return View(xUsrs);
        }


    }
}