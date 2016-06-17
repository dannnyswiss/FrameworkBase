using Base.Classes;
using Base.DataMappings;
using System.Data.Entity;

namespace Base.Data
{
    public class ReturnsContext : BaseContext<ReturnsContext>
    {
        public DbSet<CustomerReference> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Return> Returns { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new LineItemMap());
            modelBuilder.Ignore<Customer>();
            modelBuilder.Ignore<Category>();
        }
    }
}
