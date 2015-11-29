using NorthwindLab03.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace NorthwindLab03.Filters
{
    public interface IEntityFrameworkControllerInterface
    {
        NorthwindEntities Contexto { get; } 
        
    }
    public class EntityFrameworkLogFilter : ActionFilterAttribute
    {
        private StringBuilder Trace = new StringBuilder();
        // GET: Categories
        private void makeTrace(string message)
        {
            Trace.AppendLine(message);
        }

        public override void OnActionExecuting(
            ActionExecutingContext filterContext)
        {
            var controller = filterContext.Controller as IEntityFrameworkControllerInterface; 
            if (controller != null)
            {                 
                 controller.Contexto.Database.Log += makeTrace;
            }           

            base.OnActionExecuting(filterContext);
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {            
            var controller = filterContext.Controller as IEntityFrameworkControllerInterface;
            if (controller != null)
            {
                controller.Contexto.Database.Log -= makeTrace;
                filterContext.Controller.ViewBag.TraceMessage = Trace.ToString(); 
            }
            base.OnActionExecuted(filterContext);
        }
    }
}