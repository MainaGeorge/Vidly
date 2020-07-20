using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;
        // GET: Movies
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(c => c.Genre).ToList();
            return View(movies);
        }

        public ActionResult Detail(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).FirstOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();
            return View(movie);
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}