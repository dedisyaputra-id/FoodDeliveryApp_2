using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace webapifirst.Models
{
    public class ProductDTO
    {
        public string? ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string ProductDescription { get; set; }
        [Required]
        public float ProductPrice { get; set; }
        [Required]
        public int ProductCount { get; set; } = 0;
        [Required]
        public string CategoryId { get; set; } = string.Empty;
    }
}
