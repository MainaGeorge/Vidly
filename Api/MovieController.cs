﻿using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Api
{
    public class MovieController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        [Route("api/movie")]
        public IHttpActionResult GetMovies()
        {
            return Ok(_context.Movies
                .Include(m => m.Genre)
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>));
        }

        [HttpGet]
        [Route("api/movie/{id}", Name = "GetMovie")]
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies
                .Include(m => m.Genre)
                .FirstOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        [HttpPost]
        [Route("api/movie")]
        public IHttpActionResult PostMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);

            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return CreatedAtRoute("GetMovie", new { id = movieDto.Id }, movieDto);
        }

        [HttpPut]
        [Route("api/movie/{id}")]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }

            Mapper.Map(movieDto, movie);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        [Route("api/movie/{id}")]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return Ok();
        }

    }
}
