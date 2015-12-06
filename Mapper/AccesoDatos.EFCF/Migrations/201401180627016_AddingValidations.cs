namespace AccesoDatos.EFCF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingValidations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Color", c => c.String(maxLength: 15));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Color", c => c.String(maxLength: 25));
        }
    }
}
