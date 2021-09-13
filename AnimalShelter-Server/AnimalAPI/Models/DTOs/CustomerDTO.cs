namespace AnimalAPI{
    public class CustomerDTO {

        public CustomerDTO(string firstName, string lastName, string email, string phoneNr)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.PhoneNr = phoneNr;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNr { get; set; }
    }
}