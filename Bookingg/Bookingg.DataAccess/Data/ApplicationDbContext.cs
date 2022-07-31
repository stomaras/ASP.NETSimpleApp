using Booking.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookingg.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CoverType> CoverTypes { get; set; }
        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CoverType>().HasData(
                    new CoverType{ Id = 1, Name = "Fabric", Price = 20},
                    new CoverType{ Id = 2, Name = "Leather", Price = 15},
                    new CoverType{ Id = 3, Name = "Vegan", Price = 9},
                    new CoverType{ Id = 4, Name = "Sofa", Price = 35}
                );

            modelBuilder.Entity<Category>().HasData(
                    new Category { Id = 1, Name = "Vans", DisplayOrder = 1},
                    new Category { Id = 2, Name = "Adidas", DisplayOrder = 2},
                    new Category { Id = 3, Name = "Nike", DisplayOrder = 3},
                    new Category { Id = 4, Name = "Volcom", DisplayOrder = 4}
                );
        }
    }
}


