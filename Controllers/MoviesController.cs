using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        private List<Movie> _movies;
        public MoviesController()
        {
            _movies = new List<Movie>()
            {
                new Movie() {Id = 1, Name = "Baby boss"},
                new Movie() {Id = 2, Name = "Fast and Furious"},
                new Movie() {Id = 3, Name = "The Matrix"}
            };
        }
        public ActionResult Index()
        {
            return View(_movies);
        }
    }
}