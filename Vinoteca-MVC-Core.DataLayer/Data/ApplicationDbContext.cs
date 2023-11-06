using Microsoft.EntityFrameworkCore;
using Vinoteca_MVC_Core.Models.Models;

namespace Vinoteca_MVC_Core.Data
{
	public class ApplicationDbContext:DbContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
            
        }
        public DbSet<Variety> Varieties { get; set; }
        public DbSet<Winery> Wineries { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
