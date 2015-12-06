using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entidades.EFCF
{    
    public partial class ProductSubcategory
    {
        public ProductSubcategory()
        {
            this.Product = new HashSet<Product>();
        }

        [Key]
        public int ProductSubcategoryID { get; set; }
        public int ProductCategoryID { get; set; }
        public string Name { get; set; }
        public Guid RowGuid { get; set; }
        public DateTime ModifiedDate { get; set; }
    
        public virtual ICollection<Product> Product { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
    }
}
