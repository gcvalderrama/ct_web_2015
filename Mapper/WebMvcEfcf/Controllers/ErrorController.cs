using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMvcEfcf.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult NotFound()
        {
            ViewBag.ErrorDescription = "NO SE ENCONTRÓ LA PÁGINA SOLICITADA.";
            return View("Error");
        }
	}
}