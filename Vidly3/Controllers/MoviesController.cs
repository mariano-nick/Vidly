using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly3.Models;
using Vidly3.ViewModels;
using System.Data.Entity;

namespace Vidly3.Controllers
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
            return View();
        }

        // GET: Movies/Details/Id
        public ActionResult Details(int Id)
        {
            var movie = _context.Movies
                .Include(m => m.Genre)
                .FirstOrDefault(m => m.Id == Id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };

            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1"},
                new Customer { Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        // GET: Movies/Edit
        public ActionResult Edit(int Id)
        {
            var movie = _context.Movies.Single(m => m.Id == Id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new AddEditMoviesViewModel(movie)
            {
                Genres = _context.Genres.ToList()
            };

            return View("AddEditMoviesForm", viewModel);
        }

        // GET: Movies/New
        public ActionResult New()
        {
            var viewModel = new AddEditMoviesViewModel()
            {
                Genres = _context.Genres.ToList()
            };

            return View("AddEditMoviesForm", viewModel);
        }

        // POST: Movies/Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new AddEditMoviesViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };
                return View("AddEditMoviesForm", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.DateAddedToDatabase = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NumberInStock = movie.NumberInStock;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
    }
}