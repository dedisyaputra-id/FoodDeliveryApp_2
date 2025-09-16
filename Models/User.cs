using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace webapifirst.Models;
[Index(nameof(Email), Name = "IX_unique_Email", IsUnique = true)]
public class User
{
    [Key]
    public string UserId { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [MinLength(3), MaxLength(255)]
    public string FirstName { get; set; }
    [MaxLength(255)]
    public string? LastName { get; set; }
    [Required]
    [MaxLength(255)]
    public string Password { get; set; }

    public ICollection<UserRole> UserRoles { get; set; }
    public string? opAdd { get; set; }
    public string? pcAdd { get; set; }
    public DateTime? dateAdd { get; set; }
    public string? opEdit { get; set; }
    public string? pcEdit { get; set; }
    public DateTime? dateEdit { get; set; }
    public byte dlt { get; set; }
}
