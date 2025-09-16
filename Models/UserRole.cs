namespace webapifirst.Models
{
    public class UserRole
    {
        public string UserRoleId { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public string? opAdd { get; set; }
        public string? pcAdd { get; set; }
        public DateTime? dateAdd { get; set; }
        public string? opEdit { get; set; }
        public string? pcEdit { get; set; }
        public DateTime? dateEdit { get; set; }
        public byte dlt { get; set; }
    }
}
