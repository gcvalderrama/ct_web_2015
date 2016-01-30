using Movies.BL;
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
        private Movies.BL.IMoviesService MoviesService; 

        public MoviesController(IMoviesService MoviesService)
        {
            this.MoviesService = MoviesService; 
        }

        // GET: Movies
        public ActionResult Index()
        {
            var model = this.MoviesService.GetAll(); 
            return View(model);
        }
                
        [AcceptVerbs(HttpVerbs.Get| HttpVerbs.Post)]
        public ActionResult Details(int id)
        {
            var model = this.MoviesService.GetOne(id);
            if (this.Request.IsAjaxRequest())
            {
                return Json(new { title = model.Title, description = model.Description }, JsonRequestBehavior.DenyGet); 
            }
            else {                
                return this.View(model);
            }            
        }

        public ActionResult  Create()
        {
            return this.View(); 
        }

        [HttpPost]
        public ActionResult Search(string filter)
        {
            if (!this.Request.IsAjaxRequest())
            {
                return this.HttpNotFound("this action is not valid with ajax request");
            }

            var data =  this.MoviesService.SearchMovies(filter);

            var result = new { items = new List<Object>() };

            foreach (var item in data)
            {
                result.items.Add(new { title = item.Title, description = item.Description, id = item.Id }); 
            }           


            return Json( result , JsonRequestBehavior.DenyGet);
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