using System.ComponentModel.DataAnnotations;

namespace webapifirst.Models
{
    public class CategoryDTO
    {
        public string? CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
