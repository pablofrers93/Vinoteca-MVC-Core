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
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Variety>().HasData(
                    new Variety { Id = 1, VarietyName = "Malbec", DisplayOrder = 1 },
                    new Variety { Id = 2, VarietyName = "Merlot", DisplayOrder = 3 },
                    new Variety { Id = 3, VarietyName = "Tempranillo", DisplayOrder = 2 },
                    new Variety { Id = 4, VarietyName = "Sirah", DisplayOrder = 4 }
               );
        }
        public DbSet<Variety> Varieties { get; set; }
    }
}
