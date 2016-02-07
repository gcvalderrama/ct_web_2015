using Movies.BL;
using Movies.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace MoviesSite.Controllers
{
    [Authorize]
    public class MoviesController : Controller
    {
        private Movies.BL.IMoviesService MoviesService; 

        public MoviesController(IMoviesService MoviesService)
        {
            this.MoviesService = MoviesService; 
        }

        // GET: Movies
        public ActionResult Index()
        {
            var model = this.MoviesService.GetAll(); 
            return View(model);
        }

        public ActionResult Home()
        {
            return View(); 
        }

                
        [AcceptVerbs(HttpVerbs.Get| HttpVerbs.Post)]
        public ActionResult Details(int id)
        {
            var model = this.MoviesService.GetOne(id);
            if (this.Request.IsAjaxRequest())
            {
                return Json(new { title = model.Title, description = model.Description }, JsonRequestBehavior.DenyGet); 
            }
            else {                
                return this.View(model);
            }            
        }

        public ActionResult  Create()
        {
            return this.View(); 
        }

        [HttpPost]
        public ActionResult Search(string filter)
        {
            if (!this.Request.IsAjaxRequest())
            {
                return this.HttpNotFound("this action is not valid with ajax request");
            }

            var data =  this.MoviesService.SearchMovies(filter);

            var result = new { items = new List<Object>() };

            foreach (var item in data)
            {
                result.items.Add(new { title = item.Title, description = item.Description, id = item.Id }); 
            }           


            return Json( result , JsonRequestBehavior.DenyGet);
        }
        

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(Movie Model, HttpPostedFileBase files)
        {
            if(this.ModelState.IsValid)
            {
                if ( files != null )
                {
                    var fileName = string.Format("~/MovieImages/{0}", 
                        files.FileName);                                                
                    files.SaveAs(this.Server.MapPath(fileName));
                    Model.Poster = fileName; 
                }

                this.MoviesService.Create(Model);
                return this.RedirectToAction("Index");
            }
            else
            {
                return View(Model); 
            }
        }

        [OutputCache(Duration=2400, 
            VaryByParam="*", 
            Location= OutputCacheLocation.Client) ]
        public ActionResult GetMoviePoster(int Id)
        {
            var model = this.MoviesService.GetOne(Id);
            return this.File(model.Poster, 
                string.Format("image/{0}", 
                Path.GetExtension( model.Poster ))); 
        }






        public ActionResult MovieUpload()
        {
            return this.View(); 
        }
        [HttpPost]
        public ActionResult MovieUpload(
            IEnumerable<HttpPostedFileBase> files)
        {
            List<string> images = new List<string>(); 
            foreach (var item in files)
            {
                var fileName = string.Format("~/MovieImages/{0}",
                       item.FileName);
                item.SaveAs(this.Server.MapPath(fileName));

                images.Add(fileName); 
            }
                       

            return Json(images.Select(c => new { 
                path = this.Url.Content(c) }));            
        }
        public ActionResult MovieReport()
        {

            //URL del Servidor de Reporting Services
            string servidor = "http://cibertec/ReportServer";

            //Carpeta donde tenemos los reportes
            string carpeta = "Movies";

            //Nombre del Reporte
            string reporte = "MoviesReportList";

            //Los parámetros con sus respectivos valores
            string parametros = "";

            //Comandos a pasar al Visor de Reporting Services
            //http://technet.microsoft.com/es-ve/library/ms152835.aspx
            string comandosRS = "&rs:Command=Render&rs:Format=HTML4.0&rc:Parameters=false";

            var command = String.Format("<iframe id='ifReporte' width='100%' style='height: 480px' frameborder='0' src='{0}?/{1}/{2}{3}{4}'></iframe>",
                                 servidor, carpeta, reporte, parametros, comandosRS);

            ViewBag.ReporteHTML = command;
            return View();
             
        }
        public ActionResult MovieAyncReport()
        {
            return View(); 
        }
        public ActionResult MovieAyncReportJSON()
        {

            //URL del Servidor de Reporting Services
            string servidor = "http://devserver/ReportServer_SQLEXPRESS2014";

            //Carpeta donde tenemos los reportes
            string carpeta = "Movies";

            //Nombre del Reporte
            string reporte = "MovieReport";

            //Los parámetros con sus respectivos valores
            string parametros = "";

            //Comandos a pasar al Visor de Reporting Services
            //http://technet.microsoft.com/es-ve/library/ms152835.aspx
            string comandosRS = "&rs:Command=Render&rs:Format=HTML4.0&rc:Parameters=false";

            var command = String.Format("<iframe id='ifReporte' width='100%' style='height: 480px' frameborder='0' src='{0}?/{1}/{2}{3}{4}'></iframe>",
                                 servidor, carpeta, reporte, parametros, comandosRS);


            return Json(command, JsonRequestBehavior.AllowGet);            
        }
    }
}