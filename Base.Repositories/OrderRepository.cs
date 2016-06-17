using Base.Classes;
using Base.Data;
using Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Base.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        SalesContext context = new SalesContext();
        public IQueryable<Order> All
        {
            get
            {
                return context.Orders;
            }
        }

        public IQueryable<Order> AllIncluding(params Expression<Func<Order, object>>[] includedProperties)
        {
            IQueryable<Order> query = context.Orders;
            foreach (var includeProperty in includedProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Order Find(int id)
        {
            //return context.People.Find(id);
            return new Order();
        }

        public void InsertGraph(Order order)
        {
            context.Orders.Add(order);
        }

        public void InsertOrUpdateEntity(Order order)
        {
            if (order.Id == default(int))
            {
                //Existing Entity
                context.Entry(order).State = EntityState.Added;
            }
            else
            {
                //remember to keep entity framework logic here.
                //handle initilization of a new address or update the address.
                //Root:Editied and Items:SomeEdits
                //Entry(customer).State = Modified
                //Entry(*each item).State = Modified
                //Or 
                //Root: ??
                //Items:SomeAdded
                //DbSet.Add(customer)
                //Entry(*each non-New Item).State = *Correct State*
                context.Orders.Add(order);
                context.Entry(order).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var order = context.Orders.Find(id);
            context.Orders.Remove(order);
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
