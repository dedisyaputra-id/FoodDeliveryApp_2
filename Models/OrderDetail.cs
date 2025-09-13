using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace webapifirst.Models
{
    public class OrderDetail
    {
        [Key]
        [Required]
        public string OrderDetailId { get; set; }
        [Required]
        public string OrderId { get; set; }
        [Required]
        public string ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
        public Order order { get; set; }
        public Product product { get; set; }
        public string? OpAdd { get; set; }
        public string? PcAdd { get; set; }
        public DateTime? DateAdd { get; set; }
        public string? OpEdit { get; set; }
        public string? PcEdit { get; set; }
        public string? DateEdit { get; set; }
        public byte dlt { get; set; }
    }
}
