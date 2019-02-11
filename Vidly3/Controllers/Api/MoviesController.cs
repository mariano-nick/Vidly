﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly3.Dtos;
using Vidly3.Models;

namespace Vidly3.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/movies
        public IHttpActionResult GetMovies()
        {
            var moviesDtos = _context.Movies
                .Include(m => m.Genre)
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);

            return Ok(moviesDtos);
        }

        // GET /api/movies/1
        public IHttpActionResult GetMovie(int Id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == Id);

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        // POST /api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;
            return Created(Request.RequestUri + "/" + movie.Id, movieDto);
        }

        // PUT /api/movies/1
        [HttpPut]
        public IHttpActionResult UpdateMovie(int Id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == Id);

            if (movieInDb == null)
                return NotFound();

            Mapper.Map(movieDto, movieInDb);

            _context.SaveChanges();
            return Ok();
        }

        // DELETE /api/movies/1
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int Id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == Id);

            if (movieInDb == null)
                return NotFound();

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
