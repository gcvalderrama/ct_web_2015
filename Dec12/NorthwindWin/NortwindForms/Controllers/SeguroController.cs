using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NortwindForms.Controllers
{
    [Authorize(Roles = "Managers")]
    public class SeguroController : Controller
    {
        // GET: Seguro
        public ActionResult Index()
        {
            return View();
        }
    }
}