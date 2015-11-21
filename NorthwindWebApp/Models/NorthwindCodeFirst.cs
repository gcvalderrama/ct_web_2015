namespace NorthwindWebApp.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class NorthwindCodeFirst : DbContext
    {
        public NorthwindCodeFirst()
            : base("name=NorthwindCodeFirst")
        {
        }

        public virtual DbSet<Territory> Territories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Territory>()
                .Property(e => e.TerritoryDescription)
                .IsFixedLength();
        }
    }
}
