﻿using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCourse2017.ViewModels;
using MVCCourse2017.Models;

namespace MVCCourse2017.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        public ActionResult Index()
        {
            var xMovies = _context.Movies.Include(c => c.Genre).ToList();
            return View(xMovies);
        }

  // GET: Movies
        public ActionResult Edit(int id)
        {
            var xMovies = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);
            MovieVM vm = new MovieVM
            {
                Movie = xMovies,
                Genres = _context.Genres
            };
            return View("Create",vm);
        }

        [HttpPost]
        public ActionResult Save(MovieVM viewModel)
        {
            try
            {
                if (viewModel.Movie.Id < 1)
                    _context.Movies.Add(viewModel.Movie);
                else
                {
                    var xMov = _context.Movies.Include(c => c.Genre).Single(c => c.Id == viewModel.Movie.Id);
                    xMov.DateAdded = viewModel.Movie.DateAdded;
                    xMov.GenreId = viewModel.Movie.GenreId;
                    xMov.Name = viewModel.Movie.Name;
                    xMov.NumberInStock = viewModel.Movie.NumberInStock;
                    xMov.ReleaseDate = viewModel.Movie.ReleaseDate;
                }
                _context.SaveChanges();
                return RedirectToAction("Index", "Movies");
            }
            catch (Exception ex)
            {
                throw ex;
                //return RedirectToAction("Index", "Customers");
            }

        }

        // GET: Customers
        public ActionResult Create()
        {
            MovieVM vm = new MovieVM
            {Genres = _context.Genres};
            return View(vm);
        }


    }
}