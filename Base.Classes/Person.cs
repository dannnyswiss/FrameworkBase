using System.ComponentModel.DataAnnotations;

namespace Base.Classes
{
    public abstract class Person
    {
        public int Id { get; set; }
        [StringLength(10)]
        public string Title { get; set; }
        [StringLength(40)]
        public string FirstName { get; set; }
        [StringLength(40)]
        public string LastName { get; set; }
        [StringLength(100)]
        public string CompanyName { get; set; }
        [StringLength(50)]
        public string EmailAddress { get; set; }
        [StringLength(25)]
        public string Phone { get; set; }
    }
}