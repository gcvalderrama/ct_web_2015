using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entidades.EFCF
{   
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            this.ProductSubcategory = new HashSet<ProductSubcategory>();
        }
    
        [Key]
        public int ProductCategoryID { get; set; }
        public string Name { get; set; }
        public Guid RowGuid { get; set; }
        public DateTime ModifiedDate { get; set; }
    
        public virtual ICollection<ProductSubcategory> ProductSubcategory { get; set; }
    }
}
