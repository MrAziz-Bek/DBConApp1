using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DBConApp1.Entity
{
    public class InformDbContext : DbContext
    {
        public DbSet<Teacher> Teachers { get; set; }
        
        public DbSet<Student> Students { get; set; }
        protected readonly IConfiguration Configuration;

        public InformDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseInMemoryDatabase("InformDb");
        }
    }
}