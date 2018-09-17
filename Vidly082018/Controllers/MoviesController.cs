using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly082018.Models;
using Vidly082018.ViewModels;



namespace Vidly082018.Controllers
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

        public ViewResult Index()
        {

            var movies = _context.Movies.Include(c => c.Genre ).ToList();
            return View(movies);
 
        }
        public ActionResult New()
        {
            var genreTypes = _context.GenreTypes.ToList();
            var movieViewModel = new MovieFormViewModel()
            {             
                GenreTypes = genreTypes   
            };
            return View("MovieForm",movieViewModel);
        }
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();

            var movieViewModel = new MovieFormViewModel(movie)
            {
                GenreTypes = _context.GenreTypes.ToList()
            };

            return View("MovieForm", movieViewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    GenreTypes = _context.GenreTypes.ToList()
                };
                return View("MovieForm",viewModel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                // movieInDb.DateAdded = movie.DateAdded;
                movieInDb.InStock = movie.InStock;
                movieInDb.GenreId = movie.GenreId;
            }
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {

                Console.WriteLine(ex);
            }

            return RedirectToAction("Index", "Movies");
        }
        public ActionResult Cancel()
        {

            return RedirectToAction("Index","Movies");
        }

        public ActionResult Details(int id)
        {
            //var movie = GetMovies().SingleOrDefault(c => c.Id == id);
            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseYear(int? year,int? month)
        {
            return Content(year + "/" + month);
        }
        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                 new Movie{Id=1,Name="MI2" },
                new Movie{Id=2,Name="Geetha Govindam" },
                new Movie{Id=3,Name="Goodachari" }
            };
        }

    }
}