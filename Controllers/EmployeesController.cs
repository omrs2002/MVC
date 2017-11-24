using MVCCourse2017.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCourse2017.Controllers
{
    public class EmployeesController : Controller
    {
        private ApplicationDbContext _context;

        public EmployeesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Employees
        public ActionResult Random()
        {
            var Emp = new Employee
            {
                FullName = "Omar",
                Salary = 7000,
                BirthDate = DateTime.Parse("20/11/1983")
            };

            return View(Emp);
            //return Content("hello word!!");
            //return HttpNotFound();
        }

        public ActionResult Details(int id)
        {
            var xEmp = _context.Employees.SingleOrDefault(c => c.EmpID == id);
            return View(xEmp);
        }

        public ActionResult Edit(int id)
        {
            var xEmp = _context.Employees.SingleOrDefault(c => c.EmpID == id);
            return View(xEmp);
        }

        public ActionResult Index(int? id)
        {
            if (!id.HasValue)
            {
                return View(_context.Employees);
            }
            else
            {
                var xEmp = _context.Employees.SingleOrDefault(c => c.EmpID == id);
                return View(xEmp);
            }
        }
    }
}