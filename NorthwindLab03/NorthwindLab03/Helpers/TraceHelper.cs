using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html; 
namespace NorthwindLab03.Helpers
{
    public static class TraceHelper
    {
        public static MvcHtmlString RenderTrace(this HtmlHelper Helper, string Content)
        {
            if (!string.IsNullOrWhiteSpace(Content))
            {
               return Helper.TextArea("Trace",
                Content, new { cols = "100", rows = "20" });
            }
            return MvcHtmlString.Empty; 

        }
    }
}