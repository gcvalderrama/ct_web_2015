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




    }
}