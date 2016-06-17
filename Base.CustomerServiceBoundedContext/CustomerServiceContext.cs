using Base.Classes;
using Base.DataMappings;
using System.Data.Entity;

namespace Base.Data
{
    public class CustomerServiceContext : BaseContext<CustomerServiceContext>
    {
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new LineItemMap());
            modelBuilder.Entity<Shipment>();
            modelBuilder.Ignore<Category>();
        }
    }
}
