using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Base.Classes;

namespace Base.Data
{
    public class SpecificObjectRepository : ISpecificObjectRepository
    {
        SalesContext context = new SalesContext();
        public IQueryable<Customer> All
        {
            get {
                return context.Customers;
            }
        }

        public IQueryable<Customer> AllIncluding(params Expression<Func<Customer, object>>[] includedProperties)
        {
            IQueryable<Customer> query = context.Customers;
            foreach (var includeProperty in includedProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Customer Find(int id)
        {
            //return context.People.Find(id);
            return new Customer();
        }

        public void InsertOrUpdate(Customer customer)
        {
            if (customer.Id == default(int))
            {
                //Add new Entity
                context.Customers.Add(customer);
            }
            else
            {
                //Existing Entity
                context.Entry(customer).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var customer = context.Customers.Find(id);
            context.Customers.Remove(customer);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }

}
