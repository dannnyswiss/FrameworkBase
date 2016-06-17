using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base.Classes;

namespace Base.Data.Contexts
{
    public class CodeFirstContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<SalaryHistory> SalaryHistories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<LineItem> LineItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<ShippingAddress> ShippingAddresses { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Return> Returns { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new LineItemMap());
            //modelBuilder.Configurations.Add(new ShippingAddressMap());
        }
    }
}
