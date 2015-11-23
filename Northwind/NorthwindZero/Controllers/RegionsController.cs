using NorthwindZero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindZero.Controllers
{
    public class RegionsController : Controller
    {

        private Models.NorthwindModel Context = new Models.NorthwindModel();
        // GET: Regions
        public ActionResult Detail(string id)
        {
            var model = (from c in this.Context.Regions.Include("Territories")
                         where c.RegionDescription == id
                         select c).First();


            return this.View("Detail", model);
        }
        public ActionResult Create()
        {
            return View(); 
        }
        [HttpPost]
        public ActionResult Create(Region Region)
        {
            Context.Regions.Add(Region);
            Context.SaveChanges(); 

            return this.RedirectToAction("Index"); 
        }
        public ActionResult Index()
        {
            var model = Context.Regions.ToList();

            foreach (var item in model)
            {
                item.RegionDescription = item.RegionDescription.TrimEnd(); 
            }

            return this.View("IndexFull", model);
          
           
        }
    }
}