using Microsoft.EntityFrameworkCore;

namespace webapifirst.Models
{
    public class FoodDeliveryContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configured = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var connectionStringSection = configured.GetSection("ConnectionStrings");
            var defaultConnectionString = connectionStringSection["DefaultConnection"];

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(defaultConnectionString);
            }
        }

        public DbSet<Product> Products { get; set; }
    }
}
