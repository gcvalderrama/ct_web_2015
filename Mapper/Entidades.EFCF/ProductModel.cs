using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entidades.EFCF
{   
    public partial class ProductModel
    {
        public ProductModel()
        {
            this.Product = new HashSet<Product>();
        }

        [Key]
        public int ProductModelID { get; set; }
        public string Name { get; set; }
        public string CatalogDescription { get; set; }
        public string Instructions { get; set; }
        public Guid RowGuid { get; set; }
        public DateTime ModifiedDate { get; set; }
    
        public virtual ICollection<Product> Product { get; set; }
    }
}
