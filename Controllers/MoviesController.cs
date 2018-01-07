using System;
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
            if(User.IsInRole(RolesNames.CanManageMovies))
                return View(xMovies);
            else
                return View("IndexReadOnly", xMovies);
        }

         // GET: Movies
        public ActionResult IndexReadOnly()
        {
            var xMovies = _context.Movies.Include(c => c.Genre).ToList();
            return View(xMovies);
        }

        public ActionResult MoviesGrid()
        {
            var xMovies = _context.Movies.Include(c => c.Genre).ToList();
            return View(xMovies);
        }

        // GET: Movies
        [Authorize(Roles = RolesNames.CanManageMovies)]
        public ActionResult Index2()
        {
            var xMovies = _context.Movies.Include(c => c.Genre).ToList();
            return View(xMovies);
        }

        [Authorize(Roles = RolesNames.CanManageMovies)]
        public ActionResult Delete(int id)
        {
            Movie movieDto = _context.Movies.Find(id);
            if (movieDto == null)
                throw new Exception("Customer Not Found");

            _context.Movies.Remove(movieDto);
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }



        [Authorize(Roles = RolesNames.CanManageMovies)]
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


        // GET: Movies
        public ActionResult Details(int id)
        {
            var xMovies = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);
            MovieVM vm = new MovieVM
            {
                Movie = xMovies,
                Genres = _context.Genres
            };
            return View(vm);
        }

        [HttpPost]
        [Authorize(Roles = RolesNames.CanManageMovies)]
        public ActionResult Save(MovieVM viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var viewM = new MovieVM
                    {
                        Movie = viewModel.Movie,
                        Genres = _context.Genres.ToList()
                    };
                    return View("Create", viewM);
                }

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

        [Authorize(Roles = RolesNames.CanManageMovies)]
        public ActionResult Create()
        {
            MovieVM vm = new MovieVM
            {Genres = _context.Genres};
            return View(vm);
        }


    }
}