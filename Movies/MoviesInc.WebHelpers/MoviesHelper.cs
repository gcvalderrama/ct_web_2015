using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html; 
namespace MoviesInc.WebHelpers
{
        
    public static class MoviesHelper
    {
        public static MvcHtmlString 
            MoviesTextbox(this HtmlHelper htmlHelper, string Name, string Value =  "enter data")
        {  

            return htmlHelper.TextBox(Name, Value ,
                new { @data_role =  "busqueda" }
            );
        }
    }
}
