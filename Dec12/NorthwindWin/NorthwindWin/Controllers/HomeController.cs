using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace NorthwindWin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [Authorize(Roles="Managers")]
        public ActionResult Contact()
        {

            int visitas = 0; 
            if ( this.Request.Cookies["visitas"] != null)
            {
                visitas = int.Parse(this.Request.Cookies["visitas"].Value);
                
            }
            visitas += 1;
            this.Response.Cookies.Add(
                    new HttpCookie("visitas", visitas.ToString()));

            

            //if (Session["Visitas"] == null)
            //    Session["Visitas"] = 0;

            //int visitas = (int)Session["Visitas"];
            //Session["Visitas"] = visitas + 1;
                            
            ViewBag.ProcessUser = WindowsIdentity.GetCurrent().Name;
            ViewBag.ApplicationUser =
                Thread.CurrentPrincipal.Identity.IsAuthenticated ? Thread.CurrentPrincipal.Identity.Name : "Anonymous";
            ViewBag.Visitas = visitas; 
            //Thread.CurrentPrincipal.Identity.Name

            return View();
        }
    }
}