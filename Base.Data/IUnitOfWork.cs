using System;
using System.Data.Entity;

namespace Base.Data
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
