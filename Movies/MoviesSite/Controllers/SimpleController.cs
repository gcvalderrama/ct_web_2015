using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoviesSite.Controllers
{
    public class SimpleController : Controller
    {
        // GET: Simple
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string FirstName)
        {
            //Session["FirstName"] = FirstName;
            //return RedirectToAction("Index3");

            

            TempData["FirstName"] = FirstName;
            return this.RedirectToAction("Index4");

        }
        public ActionResult Index2(string mensaje)
        {
            this.ViewBag.Mensaje = mensaje;
            return View();
        }
        public ActionResult Index3()
        {
            this.ViewBag.Mensaje = Session["FirstName"];
            return View();
        }
        public ActionResult Index4()
        {
            this.ViewBag.Mensaje = TempData["FirstName"];
            return View();
        }

        public ActionResult Index5()
        {            
            return View();
        }

    }
}