using Base.Data;
using Base.Interfaces;

namespace Base.SalesBoundedContext
{
    public class UnitOfWorkSales : IUnitOfWork<SalesContext>
    {
        private readonly SalesContext _context;

        public UnitOfWorkSales()
        {
            _context = new SalesContext();
        }

        public UnitOfWorkSales(SalesContext context)
        {
            _context = context;
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public SalesContext Context
        {
            get
            {
                return _context;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
