using Base.Classes;
using Base.Interfaces.GenericInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Interfaces
{
    //interfaces specific to type
    public interface ICustomerRepository: IEntityRepository<Customer>
    {

    }
}
