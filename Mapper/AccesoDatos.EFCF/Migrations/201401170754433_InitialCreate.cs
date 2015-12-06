namespace AccesoDatos.EFCF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        ProductCategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        RowGuid = c.Guid(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProductCategoryID);
            
            CreateTable(
                "dbo.ProductSubcategories",
                c => new
                    {
                        ProductSubcategoryID = c.Int(nullable: false, identity: true),
                        ProductCategoryID = c.Int(nullable: false),
                        Name = c.String(),
                        RowGuid = c.Guid(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProductSubcategoryID)
                .ForeignKey("dbo.ProductCategories", t => t.ProductCategoryID, cascadeDelete: true)
                .Index(t => t.ProductCategoryID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        ProductNumber = c.String(nullable: false, maxLength: 25),
                        MakeFlag = c.Boolean(nullable: false),
                        FinishedGoodsFlag = c.Boolean(nullable: false),
                        Color = c.String(maxLength: 25),
                        SafetyStockLevel = c.Short(nullable: false),
                        ReorderPoint = c.Short(nullable: false),
                        StandardCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ListPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Size = c.String(maxLength: 5),
                        Weight = c.Decimal(precision: 8, scale: 2),
                        DaysToManufacture = c.Int(nullable: false),
                        ProductLine = c.String(maxLength: 2),
                        Class = c.String(maxLength: 2),
                        Style = c.String(maxLength: 2),
                        SellStartDate = c.DateTime(nullable: false),
                        SellEndDate = c.DateTime(),
                        DiscontinuedDate = c.DateTime(),
                        RowGuid = c.Guid(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        ProductModelID = c.Int(),
                        ProductSubcategoryID = c.Int(),
                        SizeUnitMeasureCode = c.String(maxLength: 3),
                        WeightUnitMeasureCode = c.String(maxLength: 3),
                        UnitMeasure_UnitMeasureCode = c.String(maxLength: 128),
                        UnitMeasure_UnitMeasureCode1 = c.String(maxLength: 128),
                        SizeUnitMeasure_UnitMeasureCode = c.String(maxLength: 128),
                        WeightUnitMeasure_UnitMeasureCode = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.ProductModels", t => t.ProductModelID)
                .ForeignKey("dbo.ProductSubcategories", t => t.ProductSubcategoryID)
                .ForeignKey("dbo.UnitMeasures", t => t.UnitMeasure_UnitMeasureCode)
                .ForeignKey("dbo.UnitMeasures", t => t.UnitMeasure_UnitMeasureCode1)
                .ForeignKey("dbo.UnitMeasures", t => t.SizeUnitMeasure_UnitMeasureCode)
                .ForeignKey("dbo.UnitMeasures", t => t.WeightUnitMeasure_UnitMeasureCode)
                .Index(t => t.ProductModelID)
                .Index(t => t.ProductSubcategoryID)
                .Index(t => t.UnitMeasure_UnitMeasureCode)
                .Index(t => t.UnitMeasure_UnitMeasureCode1)
                .Index(t => t.SizeUnitMeasure_UnitMeasureCode)
                .Index(t => t.WeightUnitMeasure_UnitMeasureCode);
            
            CreateTable(
                "dbo.ProductModels",
                c => new
                    {
                        ProductModelID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CatalogDescription = c.String(),
                        Instructions = c.String(),
                        RowGuid = c.Guid(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProductModelID);
            
            CreateTable(
                "dbo.UnitMeasures",
                c => new
                    {
                        UnitMeasureCode = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UnitMeasureCode);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductSubcategories", "ProductCategoryID", "dbo.ProductCategories");
            DropForeignKey("dbo.Products", "WeightUnitMeasure_UnitMeasureCode", "dbo.UnitMeasures");
            DropForeignKey("dbo.Products", "SizeUnitMeasure_UnitMeasureCode", "dbo.UnitMeasures");
            DropForeignKey("dbo.Products", "UnitMeasure_UnitMeasureCode1", "dbo.UnitMeasures");
            DropForeignKey("dbo.Products", "UnitMeasure_UnitMeasureCode", "dbo.UnitMeasures");
            DropForeignKey("dbo.Products", "ProductSubcategoryID", "dbo.ProductSubcategories");
            DropForeignKey("dbo.Products", "ProductModelID", "dbo.ProductModels");
            DropIndex("dbo.ProductSubcategories", new[] { "ProductCategoryID" });
            DropIndex("dbo.Products", new[] { "WeightUnitMeasure_UnitMeasureCode" });
            DropIndex("dbo.Products", new[] { "SizeUnitMeasure_UnitMeasureCode" });
            DropIndex("dbo.Products", new[] { "UnitMeasure_UnitMeasureCode1" });
            DropIndex("dbo.Products", new[] { "UnitMeasure_UnitMeasureCode" });
            DropIndex("dbo.Products", new[] { "ProductSubcategoryID" });
            DropIndex("dbo.Products", new[] { "ProductModelID" });
            DropTable("dbo.UnitMeasures");
            DropTable("dbo.ProductModels");
            DropTable("dbo.Products");
            DropTable("dbo.ProductSubcategories");
            DropTable("dbo.ProductCategories");
        }
    }
}
