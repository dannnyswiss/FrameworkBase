using Base.Classes;
using Base.CustomerServiceBoundedContext;
using Base.Data;
using Base.Interfaces;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Base.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private CustomerServiceContext _context;

        public CustomerRepository(UnitOfWorkCustomerService uow)
        {
            _context = uow.Context;
        }

        public IQueryable<Customer> All
        {
            get {
                return _context.Customers;
            }
        }

        public IQueryable<Customer> AllIncluding(params Expression<Func<Customer, object>>[] includedProperties)
        {
            IQueryable<Customer> query = _context.Customers;
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

        public void InsertGraph(Customer customer)
        {
            _context.Customers.Add(customer);
        }

        public void InsertOrUpdateGraph(Customer customerGraph)
        {
            _context.Customers.Add(customerGraph);
            if (customerGraph.State == ObjectState.Add)
            {
                _context.Customers.Add(customerGraph);
            }
            else
            {
                _context.Customers.Add(customerGraph);
                _context.ApplyStateChanges();
            }
        }

        public void InsertOrUpdateEntity(Customer customer)
        {
            if (customer.Id == default(int))
            {
                _context.Entry(customer).State = EntityState.Added;
            }
            else
            {
                _context.Customers.Add(customer);
                _context.Entry(customer).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var customer = _context.Customers.Find(id);
            _context.Customers.Remove(customer);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }

}
