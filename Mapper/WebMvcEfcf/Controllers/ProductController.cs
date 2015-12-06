using Entidades.EFCF;
using LogicaNegocio.EFCF;
using System;
using System.Web.Mvc;

namespace WebMvcEfcf.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                var prodLN = new ProductoLN();
                var productos = prodLN.SelectAll();
                return View(productos);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorDescription = ex.ToString();
                ViewData["Controller"] = ControllerContext.RouteData.Values["Controller"].ToString();
                ViewData["Action"] = ControllerContext.RouteData.Values["Action"].ToString();
                return View("Error");
            }
        }

        public ActionResult Details(int id)
        {
            try
            {
                var prodLN = new ProductoLN();
                var producto = prodLN.Select(new Product { ProductID = id });
                return View(producto);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorDescription = ex.ToString();
                ViewData["Controller"] = ControllerContext.RouteData.Values["Controller"].ToString();
                ViewData["Action"] = ControllerContext.RouteData.Values["Action"].ToString();
                return View("Error");
            }
        }

        public ActionResult CreateProduct()
        {
            try
            {
                var prodLN = new ProductoLN();
                ViewBag.ProductModels = prodLN.GetProductModels();
                ViewBag.ProductSubcategories = prodLN.GetProductSubsctegories();
                ViewBag.UnitMeasures = prodLN.GetUnitMeasures();
                return View("Create");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorDescription = ex.ToString();
                ViewData["Controller"] = ControllerContext.RouteData.Values["Controller"].ToString();
                ViewData["Action"] = ControllerContext.RouteData.Values["Action"].ToString();
                return View("Error");
            }            
        }

        //UpdateModel.
        //Observar que en este caso el metodo Create no recibe ningún parámetro como en los laboratorios anteriores,
        //ya que se va a emplear el explicit binding.
        //Por default, el binding busca los valores para llenar al producto en los siguientes lugares:
        //form data, route data, query string, uploaded files.
        //En este caso, está tomando los datos del form data (la vista) haciendo coincidir los nombres de los
        //campos de la clase product, con la propiedad name de los inputs, así, un input con name=ProductNumber,
        //llenará el valor producto.ProductNumber. 
        [HttpPost]
        public ActionResult Create()
        {
            try
            {
                //Explicit Binding usando UpdateModel                
                var producto = new Product();
                UpdateModel(producto);

                //Se puede especificar de dónde se desea que el binding tome los valores.
                //En este caso se está indicando que solo se tome los que provengan del form data.

                //UpdateModel(producto, new FormValueProvider(ControllerContext));

                var prodLN = new ProductoLN();
                producto.RowGuid = Guid.NewGuid();
                producto.ModifiedDate = DateTime.Now;
                prodLN.Insert(producto);
                return RedirectToAction("Index");
            }
            catch (InvalidOperationException iopEx)
            {
                ViewBag.ErrorDescription = "ERROR EN EL MODEL BINDING!!!" + iopEx.ToString();
                return View("Error");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorDescription = ex.ToString();
                ViewData["Controller"] = ControllerContext.RouteData.Values["Controller"].ToString();
                ViewData["Action"] = ControllerContext.RouteData.Values["Action"].ToString();
                return View("Error");
            }
        }

        //UpdateModel.
        //En este caso se está restringiendo a que solo se tomen los datos del form data.        
        //[HttpPost]
        //public ActionResult Create(FormCollection formData)
        //{
        //    try
        //    {
        //        //Explicit Binding usando UpdateModel
        //        var producto = new Product();
        //        
        //        //Tiene el mismo efecto que hacer: UpdateModel(producto, new FormValueProvider(ControllerContext))
        //        UpdateModel(producto, formData);
        //
        //        var prodLN = new ProductoLN();
        //        producto.RowGuid = Guid.NewGuid();
        //        producto.ModifiedDate = DateTime.Now;
        //        prodLN.Insert(producto);
        //        return RedirectToAction("Index");
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.ErrorDescription = ex.ToString();
        //        ViewData["Controller"] = ControllerContext.RouteData.Values["Controller"].ToString();
        //        ViewData["Action"] = ControllerContext.RouteData.Values["Action"].ToString();
        //        return View("Error");
        //    }
        //}

        //TryUpdateModel.
        //Los usuarios pueden proporcionar valores que no pueden ser enlazados a la correspondiente propiedad del modelo, 
        //tal como fechas inválidas o valores de texto para campos numéricos.
        //Cuando invocamos al model binding explícitamente, tenemos la responsabilidad de hacer frente a tales errores. 
        //El model binging expresa errores de enlace lanzando la excepción InvalidOperationException.
        //Como un enfoque alternativo, podemos utilizar el método TryUpdateModel, que devuelve true si el proceso de enlace tiene éxito
        //y false si hay errores. La única razón para favorecer el uso de TryUpdateModel sobre UpdateModel, 
        //es por la simplicidad del tratamiento de excepciones, pero no hay ninguna diferencia funcional en el proceso.
        //[HttpPost]
        //public ActionResult Create(FormCollection formData)
        //{
        //    try
        //    {
        //        //Explicit Binding usando TryUpdateModel
        //        var producto = new Product();
        //        if (TryUpdateModel(producto, formData))
        //        {
        //            var prodLN = new ProductoLN();
        //            producto.RowGuid = Guid.NewGuid();
        //            producto.ModifiedDate = DateTime.Now;
        //            prodLN.Insert(producto);
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            //Comentar el ValidationMessageFor en la vista Create para el campo ProductNumber,
        //            //con la finalidad de que la vista no valide el campo y podamos forzar un error.
        //            string error = "ERROR EN EL MODEL BINDING!!!";
        //            foreach (var modelErrors in ModelState)
        //                if (modelErrors.Value.Errors.Count > 0)
        //                    error += " - " + modelErrors.Value.Errors[0].ErrorMessage;
        //            ViewBag.ErrorDescription = error;
        //            return View("Error");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.ErrorDescription = ex.ToString();
        //        ViewData["Controller"] = ControllerContext.RouteData.Values["Controller"].ToString();
        //        ViewData["Action"] = ControllerContext.RouteData.Values["Action"].ToString();
        //        return View("Error");
        //    }
        //}

        public ActionResult Edit(int id)
        {
            try
            { 
                var prodLN = new ProductoLN();
                ViewBag.ProductModels = prodLN.GetProductModels();
                ViewBag.ProductSubcategories = prodLN.GetProductSubsctegories();
                ViewBag.UnitMeasures = prodLN.GetUnitMeasures();
                var producto = prodLN.Select(new Product { ProductID = id });
                return View(producto);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorDescription = ex.ToString();
                ViewData["Controller"] = ControllerContext.RouteData.Values["Controller"].ToString();
                ViewData["Action"] = ControllerContext.RouteData.Values["Action"].ToString();
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult Edit(Product producto)
        {
            try
            {
                var prodLN = new ProductoLN();
                producto.ModifiedDate = DateTime.Now;
                prodLN.Update(producto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorDescription = ex.ToString();
                ViewData["Controller"] = ControllerContext.RouteData.Values["Controller"].ToString();
                ViewData["Action"] = ControllerContext.RouteData.Values["Action"].ToString();
                return View("Error");
            }
        }

        public ActionResult Delete(int id)
        {
            try 
            { 
                var prodLN = new ProductoLN();
                var producto = prodLN.Select(new Product { ProductID = id });
                return View(producto);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorDescription = ex.ToString();
                ViewData["Controller"] = ControllerContext.RouteData.Values["Controller"].ToString();
                ViewData["Action"] = ControllerContext.RouteData.Values["Action"].ToString();
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var prodLN = new ProductoLN();
                prodLN.Delete(new Product { ProductID = id });
                return RedirectToAction("Index");
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
