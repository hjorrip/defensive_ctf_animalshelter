using System.ComponentModel.DataAnnotations;

namespace AnimalAPI.Models.DTOs.Requests
{
    public class UserRegistrationDTO
    {
        [Required]
        public string Username { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
