using System.ComponentModel.DataAnnotations;

namespace webapifirst.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public string? opAdd { get; set; }
        public string? pcAdd { get; set; }
        public DateTime? dateAdd { get; set; }
        public string? opEdit { get; set; }
        public string? pcEdit { get; set; }
        public DateTime? dateEdit { get; set; }
        public byte dlt { get; set; }
    }
}
