using CurvaStore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace CurvaStore.DataBase
{
    public class ApplicationDbContext :IdentityDbContext<CurvaUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options) { 
        
        
        }
        public DbSet<Category> categories { get; set; }
        public DbSet<ColorSize> colorsAndSizes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category { id = 1, Name = "Football Wear" },
                new Category { id = 2, Name = "Football" },
                new Category { id = 3, Name = "Sports Bags" },
                new Category { id = 4, Name = "Clothing" },
                new Category { id = 5, Name = "Accessories" },
                new Category { id = 6, Name = "Sports Shoes" }
                );
            modelBuilder.Entity<ColorSize>().HasKey(nameof(ColorSize.id),nameof(ColorSize.ProductId));
        }

        public DbSet<Product> products { get; set; }
        public DbSet<Blog> blogs { get; set; }
        public DbSet<ContactUs> messages { get; set; }
        public DbSet<Cart> carts { get; set; }
        public DbSet<WishList>wishLists { get; set; }
    }
}
