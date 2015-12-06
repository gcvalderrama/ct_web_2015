using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entidades.EFCF;
using WebMvcEfcf.Utils;

namespace WebMvcEfcf.ModelBinders
{
    public class ProductBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext,
            ModelBindingContext bindingContext)
        {
            var request = controllerContext.RequestContext.HttpContext.Request;

            Product model = (Product)bindingContext.Model ?? 
                new Product();

            
            model.ProductNumber = Service.GetProductNumber();

            model.Name = request.Form["Name"];
            model.SafetyStockLevel = short.Parse(request.Form["SafetyStockLevel"]);
            model.ReorderPoint = short.Parse(request.Form["ReorderPoint"]);
            model.StandardCost = decimal.Parse(request.Form["StandardCost"]);
            model.ListPrice = decimal.Parse(request.Form["ListPrice"]);
            model.DaysToManufacture = int.Parse(request.Form["DaysToManufacture"]);
            model.SellStartDate = DateTime.Parse(request.Form["SellStartDate"]);

            return model;
        }
    }
}