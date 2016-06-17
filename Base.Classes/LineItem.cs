using System;

namespace Base.Classes
{
    public class LineItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int OrderQty { get; set; }
        public Nullable<decimal> UnitePrice { get; set; }
        public Nullable<decimal> UnitPriceDiscount { get; set; }
        public decimal LineTotal { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
        public Nullable<int> ShipmentId { get; set; }
    }
}
