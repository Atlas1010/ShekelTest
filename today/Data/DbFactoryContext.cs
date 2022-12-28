using Microsoft.EntityFrameworkCore;
using today.Entities;

namespace today.Data
{
    public class DbFactoryContext:DbContext
    {
        public DbFactoryContext(DbContextOptions<DbFactoryContext> options) : base(options)
        { }
        public DbSet<Factory> Factories { get; set; } = null!;
    }
}
