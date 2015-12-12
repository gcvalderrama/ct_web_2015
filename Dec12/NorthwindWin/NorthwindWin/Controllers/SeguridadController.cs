using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace NorthwindWin.Controllers
{
    public class SeguridadController : Controller
    {
        // GET: Seguridad
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string Username, string Password)
        {
            bool result = IsValid(Username, Password); 

            if (result)
            {
                var auth = FormsAuthentication.GetAuthCookie(Username, false);
                this.Response.Cookies.Add(auth);
                return this.RedirectToAction("Index", "Home");
            }
            else
            {
                return new HttpStatusCodeResult(401);
            }
            //base  

        }

        public ActionResult Logout()
        {

            return View();
        }
        [HttpPost]
        [ActionName("Logout")]
        public ActionResult  LogoutPost()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon(); 
            return this.RedirectToAction("Index", "Home");
        }

        private  bool IsValid(string username, string password)
        {
            return username == password;
        }

    }
}