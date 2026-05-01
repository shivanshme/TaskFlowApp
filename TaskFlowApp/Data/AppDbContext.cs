using Microsoft.EntityFrameworkCore;
using TaskFlowApp.Models;

namespace TaskFlowApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<TaskCard> TaskCards { get; set; }
        public DbSet<Models.Timer> Timers { get; set; }
    }
}
