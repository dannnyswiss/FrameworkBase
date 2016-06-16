using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Classes
{
    public class Customer : Person
    {
        public Customer()
        {
            Orders = new List<Order>();
        }
        public ICollection<Order> Orders { get; set; }
        public string SalesPersonId { get; set; }
    }
}
