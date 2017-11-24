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

namespace MVCCourse2017.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Movies
        [HttpGet]
        public IQueryable<MovieDto> GetMovieDtoes()
        {
            return db.MovieDtoes;
        }

        // GET: api/Movies/5
        [ResponseType(typeof(MovieDto))]
        [HttpGet]
        public MovieDto GetMovieDto(int id)
        {
            MovieDto movieDto = db.MovieDtoes.Find(id);
            if (movieDto == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return movieDto;
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
                if (!MovieDtoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
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

            db.MovieDtoes.Add(movieDto);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = movieDto.Id }, movieDto);
        }

        // DELETE: api/Movies/5
        public IHttpActionResult DeleteMovieDto(int id)
        {
            MovieDto movieDto = db.MovieDtoes.Find(id);
            if (movieDto == null)
            {
                return NotFound();
            }

            db.MovieDtoes.Remove(movieDto);
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