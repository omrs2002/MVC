using AutoMapper;
using MVCCourse2017.DTOs;
using MVCCourse2017.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCourse2017.Controllers
{
    public class RentalsController : Controller
    {
        private ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Rentals
        public ActionResult Index()
        {
            var renLst = _context.Rentals.Include(m => m.Customer).Include(b=>b.Movie).ToList();
            //var renDto = Mapper.Map<Rental, NewRentalDto>(renLst);
            return View(renLst);
        }
  

        public ActionResult RentalGrid()
        {
            var renLst = _context.Rentals.Include(m => m.Customer).Include(b=>b.Movie).ToList();
            return View(renLst);
        }
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult CreateWClintVal()
        {return View();}

        public ActionResult Delete(int id)
        {
            var xrent = _context.Rentals.Single(c => c.Id == id);
            if (xrent == null)
                throw new Exception("Rentals Not Found");
            _context.Rentals.Remove(xrent);
            _context.SaveChanges();
            return RedirectToAction("Index", "Rentals");
        }
        



    }
}