
using System.ComponentModel.DataAnnotations;

namespace AnimalAPI{
    
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNr { get; set; }

    }
}