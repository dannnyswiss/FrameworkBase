using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Base.Classes
{
    [Table("ShippingAddresses")]
    public class ShippingAddress : IObjectWithState
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Street2 { get; set; }
        [StringLength(50)]
        public string City { get; set; }
        [StringLength(50)]
        public string Street1 { get; set; }
        [StringLength(50)]
        public string Region { get; set; }
        [StringLength(50)]
        public string Country { get; set; }
        [StringLength(50)]
        public string PostalCode { get; set; }
        [StringLength(50)]
        public Customer Customer { get; set; }
        [StringLength(50)]
        public int CustomerId { get; set; }
        [NotMapped]
        public ObjectState State { get; set; }
    }
}
