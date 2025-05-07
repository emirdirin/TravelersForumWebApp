using Microsoft.EntityFrameworkCore;

namespace Homework1.Models {
    public class PlaceDbContext : DbContext {
        
        
        public PlaceDbContext(DbContextOptions<PlaceDbContext> options): base(options) { }
        
        public DbSet<Place> Places => Set<Place>();
    

        /* 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>().ToTable("Product");
            modelBuilder.Entity<ProductCategories>().ToTable("ProductCategory");
        }
        */
    }
}