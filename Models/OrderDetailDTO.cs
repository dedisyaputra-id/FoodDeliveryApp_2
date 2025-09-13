using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace webapifirst.Models
{
    public class OrderDetailDTO
    {
        public string? OrderDetailId { get; set; }
        [Required]
        public string ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
