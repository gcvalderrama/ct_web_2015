using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CalApp.Controllers
{
    public class CalculadoraController : Controller
    {

        private Servicios.CalculadoraServicio Servicio = new Servicios.CalculadoraServicio(); 

        // GET: Calculadora
        public ActionResult Index()
        {
            ViewBag.Input1  =  0; 
            ViewBag.Input2  =  0;
            ViewBag.Result = 0;  
            return View();
        }

        [HttpPost]
        public ActionResult Index(string input1, string input2)
        {
            ViewBag.Input1  =  int.Parse(input1); 
            ViewBag.Input2  =  int.Parse(input2);
            ViewBag.Result = int.Parse(input1) + int.Parse(input2); 
            return View(); 
        }

        [HttpPost]
        public ActionResult Sumar(string input1, string input2)
        {
        
            if(!this.Request.IsAjaxRequest() )
            {
                return HttpNotFound("sumar is only for async invocations");
            }
            var v1 = int.Parse(input1); 
            var v2 = int.Parse(input2);            
            return Json(new { result = Servicio.Sumar(v1, v2) }, JsonRequestBehavior.DenyGet); 
        }

    }
}