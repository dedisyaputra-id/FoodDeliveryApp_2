using Microsoft.EntityFrameworkCore;

namespace webapifirst.Models
{
    public class FoodDeliveryContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=FoodDelivery;Trusted_Connection=True;Encrypt=False");
        }

        public DbSet<Product> Products { get; set; }
    }
}
