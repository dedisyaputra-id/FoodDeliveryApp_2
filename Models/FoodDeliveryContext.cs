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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>().HasData(
                new Role{ Id = 1, Name = "Admin", Description ="Role for admin"},
                new Role { Id = 2, Name = "User", Description = "Role for user" }
            );
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}
