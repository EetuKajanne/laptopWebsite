using laptopWebsite.Models;
using Microsoft.EntityFrameworkCore;

namespace laptopWebsite.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // This line tells EF Core: "Create a table called 'Laptops' based on the Laptop class"
        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Laptop>()
                .Property(p => p.Price)
                .HasPrecision(18, 2); // 18 digits total, 2 decimal places. This is done to be precise with decimals, since this is used for money.
        }
    }
}
