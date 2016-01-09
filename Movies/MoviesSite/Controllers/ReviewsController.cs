using Movies.BL;
using Movies.Entities;
using MoviesSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoviesSite.Controllers
{
    [Authorize]
    public class ReviewsController : Controller
    {
        private IMoviesService MoviesService;

        public ReviewsController(IMoviesService MoviesService)
        {
            this.MoviesService = MoviesService; 
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create(int Movie)
        {
            Session["MovieId"] = Movie; 
            //ViewData["MovieId"] = Movie.ToString();            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int Movie, ReviewVM Model)
        {
            
            //[Bind(Include="Comment,Score")]
            if (this.ModelState.IsValid)
            {
                //Model.MovieId = Movie; 
                Model.MovieId = (int)Session["MovieId"];

                var input = AutoMapper.Mapper.Map<Review>(Model);
                this.MoviesService.CreateReview(input);


                Session["MovieId"] = null; 
                
                return this.RedirectToAction("Details", "Movies", new { id = Model.MovieId });
            }
            else
            {
                return View(Model);

            }
        }

    }
}