using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entidades.EFCF
{    
    public partial class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Debe ingresar el campo Name.")]
        [MaxLength(50, ErrorMessage = "El campo Name no debe exceder los 50 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Ingrese el campo ProductNumber")]
        [MaxLength(25, ErrorMessage = "El campo ProductNumber no debe exceder los 25 caracteres.")]
        public string ProductNumber { get; set; }

        [Required(ErrorMessage = "Debe ingresar el campo MakeFlag.")]
        public bool MakeFlag { get; set; }

        [Required(ErrorMessage = "Debe ingresar el campo FinishedGoodsFlag.")]
        public bool FinishedGoodsFlag { get; set; }

        [MaxLength(15, ErrorMessage = "El campo Color no debe exceder los 15 caracteres.")]
        public string Color { get; set; }

        [Required(ErrorMessage = "Debe ingresar el campo SafetyStockLevel.")]
        public short SafetyStockLevel { get; set; }

        [Required(ErrorMessage = "Debe ingresar cel ampo ReorderPoint.")]
        public short ReorderPoint { get; set; }

        [Required(ErrorMessage = "Debe ingresar el campo StandardCost.")]
        [DataType(DataType.Currency)]
        public decimal StandardCost { get; set; }

        [Required(ErrorMessage = "Debe ingresar el campo ListPrice.")]
        [DataType(DataType.Currency)]
        public decimal ListPrice { get; set; }

        [MaxLength(5, ErrorMessage = "El campo Size no debe exceder los 5 caracteres.")]
        public string Size { get; set; }

        //Ver validacion en AdventureWorksContext.OnModelCreating()
        public decimal? Weight { get; set; }

        [Required(ErrorMessage = "Debe ingresar el campo DaysToManufacture.")]
        [Range(0, int.MaxValue, ErrorMessage = "El campo DaysToManufacture debe ser un numero positivo.")]
        public int DaysToManufacture { get; set; }

        [MaxLength(2, ErrorMessage = "El campo ProductLine no debe exceder los 2 caracteres.")]
        public string ProductLine { get; set; }

        [MaxLength(2, ErrorMessage = "El campo Class no debe exceder los 2 caracteres.")]
        public string Class { get; set; }

        [MaxLength(2, ErrorMessage = "El campo Style no debe exceder los 2 caracteres.")]
        public string Style { get; set; }
        
        [Required(ErrorMessage = "Debe ingresar el campo SellStartDate.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime SellStartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? SellEndDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DiscontinuedDate { get; set; }
        
        public Guid RowGuid { get; set; }

        [Required(ErrorMessage = "Debe ingresar el campo ModifiedDate.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ModifiedDate { get; set; }
        
        public int? ProductModelID { get; set; }

        public int? ProductSubcategoryID { get; set; }

        [MaxLength(3, ErrorMessage = "El campo SizeUnitMeasureCode no debe exceder los 3 caracteres.")]
        public string SizeUnitMeasureCode { get; set; }

        [MaxLength(3, ErrorMessage = "El campo WeightUnitMeasureCode no debe exceder los 3 caracteres.")]
        public string WeightUnitMeasureCode { get; set; }

        public virtual ProductModel ProductModel { get; set; }
        public virtual ProductSubcategory ProductSubcategory { get; set; }
        public virtual UnitMeasure SizeUnitMeasure { get; set; }
        public virtual UnitMeasure WeightUnitMeasure { get; set; }
    }
}
