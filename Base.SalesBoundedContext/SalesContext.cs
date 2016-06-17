using Base.Classes;
using Base.DataMappings;
using System.Data.Entity;

namespace Base.Data
{
    public class SalesContext : BaseContext<SalesContext>
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<LineItem> LineItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Payment> Paymets { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Promotion> Promotions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new LineItemMap());
            // modelBuilder.Entity<LineItem>().Ignore(c => c.LineTotal);
        }
    }
}
