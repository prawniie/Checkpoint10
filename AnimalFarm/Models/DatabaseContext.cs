using Microsoft.EntityFrameworkCore;

namespace AnimalFarm.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
    }
}
