using Movies.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.DAC
{
    public class MoviesDbContext : DbContext
    {
        public DbSet<Entities.Movie> Movies { get; set; }
        public DbSet<Entities.Review> Reviews { get; set; }
        public MoviesDbContext(): base("Movies")
        {
            
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Review>().ToTable("Reviews").HasKey(c => c.Id);
            modelBuilder.Entity<Movie>().ToTable("Movies").HasKey(c => c.Id).HasMany(c=>c.Reviews).WithOptional(c=>c.Movie).HasForeignKey(c=>c.MovieId);            
        }
    }
}
