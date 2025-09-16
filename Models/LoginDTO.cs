using System.ComponentModel.DataAnnotations;

namespace webapifirst.Models
{
    public class LoginDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required, MinLength(8)]
        public string Password { get; set; }
    }
}
