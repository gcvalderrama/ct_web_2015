using NorthwindLab03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace NorthwindLab03.Controllers
{
    public class CategoriesController : Controller
    {

        private Models.NorthwindEntities Contexto =
            new Models.NorthwindEntities();

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            this.Contexto.Dispose(); 
        }
        private StringBuilder Trace = new StringBuilder(); 
        // GET: Categories
        private void makeTrace(string message)
        {
            Trace.AppendLine(message);            
        }
        public ActionResult Index()
        {
            this.Contexto.Database.Log += makeTrace; 

            var query = from c in this.Contexto.Categories
                        select c;

            var result = query.ToList();

            this.Contexto.Database.Log -= makeTrace;

            ViewBag.TraceMessage = Trace.ToString(); 
            return View(result);
        }
        public ActionResult Details(int id)
        {
            var query = (from c in this.Contexto.Categories
                        where c.CategoryID == id
                        select c).FirstOrDefault();
            if (query == null)
                return this.HttpNotFound();
            return this.View(query); 
        }


        public ActionResult Create()
        {
            return this.View();
        }
        [HttpPost]
        public ActionResult Create(
            [Bind(Include="CategoryName,Description")]Categories Model)
        {
            
            if (!this.ModelState.IsValid)
            {
                return this.View(Model);
            }

            if (Model.CategoryName == Model.Description )
            {
                //this.ModelState.Clear();
                this.ModelState.AddModelError("", "Category must not equal description");
                return this.View(Model);
            }
            try
            {
                this.Contexto.Categories.Add(Model);
                this.Contexto.SaveChanges();
                return this.RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError("", ex);
                return this.View(Model);
            }
            
        }

        public ActionResult Delete(int id)
        {
            var  category =  this.Contexto.Categories.Find(id);
            if (category == null)
                return this.HttpNotFound();

            return this.View(category);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult PostDelete(int id)
        {
            var category = this.Contexto.Categories.Find(id);
            if (category != null)
            {
                try
                {
                    this.Contexto.Categories.Remove(category);
                    this.Contexto.SaveChanges(); 
                }
                catch (Exception ex)
                {
                    this.ModelState.AddModelError("", ex);
                    return this.View(category);                    
                }               
            }
            return this.RedirectToAction("Index");
        }



    }
}