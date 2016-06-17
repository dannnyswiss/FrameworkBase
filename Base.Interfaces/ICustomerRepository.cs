using Base.Classes;
using Base.Interfaces.GenericInterface;

namespace Base.Interfaces
{
    //interfaces specific to type
    public interface ICustomerRepository : IEntityRepository<Customer>
    {

    }
}
