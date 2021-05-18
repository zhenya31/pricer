using Microsoft.EntityFrameworkCore;

namespace Pricer_v3.Data
{
    public class MonitorItemDbContext : DbContext
    {
        public DbSet<MonitorItem> MonitorItems { get; set; }
        public DbSet<User> Users { get; set; }

        public MonitorItemDbContext(DbContextOptions<MonitorItemDbContext> options) 
            : base(options)
        { }
    }
}