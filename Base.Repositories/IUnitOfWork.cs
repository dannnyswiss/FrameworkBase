using System;
using System.Data.Entity;

namespace Base.Repositories
{
    public interface IUnitOfWork<TContext> : IDisposable where TContext : DbContext
    {
        int Save();
        TContext Context
        {
            get;
        }
    }
}
