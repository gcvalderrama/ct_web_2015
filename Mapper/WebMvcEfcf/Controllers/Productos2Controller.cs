using LogicaNegocio.EFCF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMvcEfcf.Controllers
{
    public class Productos2Controller : Controller
    {
        // GET: Productos2
        public ActionResult Index()
        {

            try
            {
                var prodLN = new ProductoLN();
                var productos = prodLN.SelectAll();
                
                var pvm = AutoMapper.Mapper.Map<IEnumerable<Models.ProductoVM>>(productos);
                
                return View(pvm);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorDescription = ex.ToString();
                ViewData["Controller"] = ControllerContext.RouteData.Values["Controller"].ToString();
                ViewData["Action"] = ControllerContext.RouteData.Values["Action"].ToString();
                return View("Error");
            }

            
        }
    }
}