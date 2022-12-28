using Microsoft.EntityFrameworkCore;
using today.Entities;

namespace today.Data
{
    public class DbGroupContext:DbContext
    {
        public DbGroupContext(DbContextOptions<DbGroupContext> options) : base(options)
        { }
        public DbSet<Group> Groups { get; set; } = null!;
    }
}
