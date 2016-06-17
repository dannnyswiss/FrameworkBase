using Base.Data;
using Base.Interfaces;

namespace Base.UnitOfWork
{
    public class UnitOfWorkCustomerService : IUnitOfWork<CustomerServiceContext>
    {
        private readonly CustomerServiceContext _context;

        public UnitOfWorkCustomerService()
        {
            _context = new CustomerServiceContext();
        }

        public UnitOfWorkCustomerService(CustomerServiceContext context)
        {
            _context = context;
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public CustomerServiceContext Context
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
