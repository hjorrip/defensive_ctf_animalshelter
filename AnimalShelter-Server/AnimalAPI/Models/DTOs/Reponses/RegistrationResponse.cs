using System.ComponentModel.DataAnnotations;
using AnimalAPI.Configuration;

namespace AnimalAPI.Models.DTOs.Responses
{
    public class RegistrationResponse : AuthResult
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}