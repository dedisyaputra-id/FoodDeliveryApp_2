using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace webapifirst.Models
{
    public class Product
    {
        [Required]
        [Key]
        [BindNever]
        public string ProductId { get; set; }
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
        [Required]
        public Category Category { get; set; }

        public string? opAdd { get; set; }
        public string? pcAdd { get; set; }
        public DateTime? dateAdd { get; set; }
        public string? opEdit { get; set; }
        public string? pcEdit { get; set; }
        public DateTime? dateEdit { get; set; }
        public byte? dlt { get; set; }
    }
}
