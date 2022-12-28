using Microsoft.EntityFrameworkCore;
using today.Entities;

namespace today.Data
{
    public class DbFactoriesToCustomerContext:DbContext
    {
        public DbFactoriesToCustomerContext(DbContextOptions<DbFactoriesToCustomerContext> options) : base(options)
        { }
        public DbSet<FactoriesToCustomer> FactoriesToCustomer { get; set; } = null!;
        public DbSet<GroupCustomers> GroupCustomers { get; set; } = null!;
    }
}
