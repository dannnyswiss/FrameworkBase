using System;
using System.Data;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base.Classes;

namespace Base.Data
{
    public class ReturnsContext: BaseContext<ReturnsContext>
    {
        public DbSet<CustomerReference> Customers { get;  set; }
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
