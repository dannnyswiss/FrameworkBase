using Base.Classes;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Base.Data
{
    public interface ISpecificObjectRepository
    {
        IQueryable<Customer> All { get; }
        IQueryable<Customer> AllIncluding(params Expression<Func<Customer, object>>[] includedProperties);
        Customer Find(int id);
        void InsertOrUpdate(Customer person);
        void Delete(int id);
        void Save();
    }
}