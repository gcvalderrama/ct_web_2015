using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindZero.Controllers
{
    public class StatusController : Controller
    {
        // GET: Status
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult QueryViewer(string id)
        {
            this.ViewBag.Server = id; 
            return this.View();  
        }
    }
}