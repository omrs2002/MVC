using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MVCCourse2017.Models;
using AutoMapper;

namespace MVCCourse2017.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        public IEnumerable<MovieDto> GetMoviesQ(string query = null)
        {
            var moviesQuery = db.Movies
                .Include(m => m.Genre)
                .Where(m => m.NumberInStock > 0);

            if (!String.IsNullOrWhiteSpace(query))
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));

            return moviesQuery
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);
        }



        // GET: api/Movies
        [HttpGet]
        public IEnumerable<MovieDto> GetMovieDtoes()
        {
            return db.Movies.ToList().Select
                (
                    Mapper.Map<Movie, MovieDto>
                );
        }

        [ResponseType(typeof(MovieDto))]
        [HttpGet]
        public IHttpActionResult GetMovieDto(int id)
        {
            Movie movie = db.Movies.Single(m => m.Id== id);
            if (movie == null)
                return NotFound();

            var xDto = Mapper.Map<Movie, MovieDto>(movie);

            return Ok(xDto);
        }

        // PUT: api/Movies/5
        [ResponseType(typeof(void))]
        [HttpPut]
        public IHttpActionResult PutMovieDto(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != movieDto.Id)
            {
                return BadRequest();
            }

            db.Entry(movieDto).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Movies

        [HttpPost]
        public IHttpActionResult PostMovieDto(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var x = Mapper.Map<MovieDto, Movie>(movieDto);

            db.Movies.Add(x);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = movieDto.Id }, movieDto);
        }

        // DELETE: api/Movies/5
        public IHttpActionResult DeleteMovieDto(int id)
        {
            Movie movieDto = db.Movies.Find(id);
            if (movieDto == null)
            {
                return NotFound();
            }

            db.Movies.Remove(movieDto);
            db.SaveChanges();

            return Ok(movieDto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }
    }
}