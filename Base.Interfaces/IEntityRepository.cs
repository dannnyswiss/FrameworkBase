using Base.Classes;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Base.Interfaces
{
    public interface IEntityRepository<T> : IDisposable 
    {
        IQueryable<T> All { get; }
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includedProperties);
        T Find(int id);
        void InsertGraph(T entity); 
        void InsertOrUpdateEntity(T entity);
        void Delete(int id);
        void Save();
    }
}