using Microsoft.EntityFrameworkCore;
using Vinoteca_MVC_Core.Models.Models;

namespace Vinoteca_MVC_Core.Data
{
	public class ApplicationDbContext:DbContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Variety>().HasData(
                new Variety { Id = 1, VarietyName = "Malbec", DisplayOrder = 3 },
                new Variety { Id = 2, VarietyName = "Merlot", DisplayOrder = 3 },
                new Variety { Id = 3, VarietyName = "Cabernet Souvignon", DisplayOrder = 3 }
                );
        }
        public DbSet<Variety> Varieties { get; set; }
        public DbSet<Winery> Wineries { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
