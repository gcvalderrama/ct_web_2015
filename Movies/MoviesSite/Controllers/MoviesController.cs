using Movies.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoviesSite.Controllers
{
    [Authorize]
    public class MoviesController : Controller
    {
        private Movies.BL.IMoviesService MoviesService = new Movies.BL.MoviesService(); 
        // GET: Movies
        public ActionResult Index()
        {
            var model = this.MoviesService.GetAll(); 
            return View(model);
        }


        public ActionResult Details(int id)
        {
            var model = this.MoviesService.GetOne(id);
            return this.View(model);
        }

        public ActionResult  Create()
        {
            return this.View(); 
        }

        

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(Movie Model)
        {
            if(this.ModelState.IsValid)
            {
                this.MoviesService.Create(Model);
                return this.RedirectToAction("Index");
            }
            else
            {
                return View(Model); 
            }
        }

    }
}