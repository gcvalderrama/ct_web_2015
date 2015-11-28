using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NorthwindLab03.Models
{
    [MetadataType(typeof(CategoriesValidation))]
    public partial class Categories
    {

    }
    public class CategoriesValidation
    {
        [Required]
        public string CategoryName { get; set; }
        [Required]
        public string Description { get; set; }
    }
}