using Microsoft.EntityFrameworkCore;
using DataAccess;

namespace SengWeb.Data
{
    public class SengWebContext : DbContext
    {
        public SengWebContext(DbContextOptions<SengWebContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Category { get; set; } = default!;
        public DbSet<Customer> Customer { get; set; } = default!;
        public DbSet<Product> Product { get; set; } = default!;
        public DbSet<Employee> Employee { get; set; } = default!;
        public DbSet<Order> Order { get; set; } = default!;
        public DbSet<OrderDetail> OrderDetail { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().ToTable("Orders");

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OrderDetail", tb => tb.HasTrigger("trg_OrderDetail_Calculate"));

                entity.HasKey(od => new { od.OrderID, od.ProductID });
            });
        }
    }
}