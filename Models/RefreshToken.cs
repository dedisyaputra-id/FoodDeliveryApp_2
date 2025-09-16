using System.ComponentModel.DataAnnotations;

namespace webapifirst.Models
{
    public class RefreshToken
    {
        [Required]
        [Key]
        public string RefreshTokenId { get; set; }
        [Required]
        public string RefreshTokenSecret { get; set; }
        [Required]
        public string userId { get; set; }
        [Required]
        public DateTime ExpiresAt {  get; set; }
        public byte IsRevoke { get; set; }
    }
}
