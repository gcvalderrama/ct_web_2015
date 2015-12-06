using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entidades.EFCF
{   
    public partial class UnitMeasure
    {
        public UnitMeasure()
        {
            this.ProductSizeList = new HashSet<Product>();
            this.ProductWeightList = new HashSet<Product>();
        }

        [Key]
        public string UnitMeasureCode { get; set; }
        public string Name { get; set; }
        public DateTime ModifiedDate { get; set; }
    
        public virtual ICollection<Product> ProductSizeList { get; set; }
        public virtual ICollection<Product> ProductWeightList { get; set; }
    }
}
