using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly3.Models;
using Vidly3.ViewModels;

namespace Vidly3.Controllers
{
    public class MoviesController : Controller
    {
        private List<Movie> _movies = new List<Movie>()
        {
            new Movie(){ Name = "Shrek!", Id = 1 },
            new Movie(){ Name = "Pirates of the Carrabean", Id = 2 }
        };

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

        // GET: Movies
        public ActionResult Index()
        {
            var viewModel = new MoviesIndexViewModel() { Movies = _movies };
            return View(viewModel);
        }

        // GET: Movies/Details/Id
        public ActionResult Details(int Id)
        {
            if (!_movies.Any(m => m.Id == Id))
            {
                return HttpNotFound();
            }

            var movie = _movies.FirstOrDefault(c => c.Id == Id);
            return View(movie);
        }
    }
}