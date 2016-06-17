using Base.Data;

namespace Base.BoundedContextCustomers
{
    public class UnitOfWorkCustomer : IUnitOfWork<CustomerContext>
    {
        private readonly CustomerContext _context;

        public UnitOfWorkCustomer()
        {
            _context = new CustomerContext();
        }

        public UnitOfWorkCustomer(CustomerContext context)
        {
            _context = context;
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public CustomerContext Context
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
