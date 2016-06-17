using Base.Classes;
using Base.Data;
using Base.DataMappings;
using System.Data.Entity;

namespace Base.BoundedContextCustomers
{
    public class CustomerContext : BaseContext<CustomerContext>
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
