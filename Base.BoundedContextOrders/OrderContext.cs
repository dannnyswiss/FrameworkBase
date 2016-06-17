using Base.Classes;
using Base.Data;
using System.Data.Entity;

namespace Base.BoundedContextOrders
{
    public class OrderContext : BaseContext<OrderContext>
    {
        public DbSet<Order> Orders { get; set; }
    }
}