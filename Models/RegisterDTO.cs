using System.ComponentModel.DataAnnotations;

namespace webapifirst.Models
{
    public class RegisterDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(3), MaxLength(255)]
        public string FirstName { get; set; }
        [MaxLength(255)]
        public string? LastName { get; set; }
        [Required]
        [MaxLength(255), MinLength(8)]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; } = "User";
    }
}
