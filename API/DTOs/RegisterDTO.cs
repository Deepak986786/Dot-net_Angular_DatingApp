using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class RegisterDTO
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; } = "";

        [Required]
        public string Name { get; set; } = "";

        [Required]
        public string Password { get; set; } = "";
    }
}
