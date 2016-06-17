using System.Collections.Generic;

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
