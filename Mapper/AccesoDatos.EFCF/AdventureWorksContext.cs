using Entidades.EFCF;
using System.Data.Entity;

namespace AccesoDatos.EFCF
{
    public class AdventureWorksContext : DbContext
    {
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductModel> ProductModels { get; set; }
        public virtual DbSet<ProductSubcategory> ProductSubcategories { get; set; }
        public virtual DbSet<UnitMeasure> UnitMeasures { get; set; }

        public AdventureWorksContext() : base("name=AdventureWorksContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(x => x.Weight).HasPrecision(8, 2);

            base.OnModelCreating(modelBuilder);
        }
    }
}
