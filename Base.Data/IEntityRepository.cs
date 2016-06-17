using System;
using System.Linq;
using System.Linq.Expressions;

namespace Base.Data
{
    public interface IEntityRepository<T> : IDisposable
    {
        IQueryable<T> All { get; }
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includedProperties);
        T Find(int id);
        void InsertGraph(T entity);
        void InsertOrUpdateEntity(T entity);
        void Delete(int id);
        //void Save();
    }
}