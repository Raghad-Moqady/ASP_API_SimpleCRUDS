using App1.Models;
using Microsoft.EntityFrameworkCore;

namespace App1.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.;Database=API_app1;Trusted_Connection=True;TrustServerCertificate=True");
        }

    }
}
