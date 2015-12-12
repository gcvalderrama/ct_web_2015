using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindWin.Controllers
{
    [Authorize]
    public class RegionesController : Controller
    {
        // GET: Regiones
        public ActionResult Index()
        {
            var context = new Models.NorthwindEntities();  

            var regiones = context.Region.ToList();

            return View(regiones);
        }
    }
}