using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoviesSite.Controllers
{
    public class MoviesController : Controller
    {
        private Movies.BL.IMoviesService MoviesService = new Movies.BL.MoviesService(); 
        // GET: Movies
        public ActionResult Index()
        {
            var model = this.MoviesService.GetAll(); 
            return View(model);
        }

    }
}