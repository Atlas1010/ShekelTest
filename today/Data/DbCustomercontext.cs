using Microsoft.EntityFrameworkCore;
using today.Entities;

namespace today.Data
{
    public class DbCustomercontext:DbContext
    {
        public DbCustomercontext(DbContextOptions<DbCustomercontext> options) : base(options)
        { }
        public DbSet<Customer> Customers { get; set; } = null!;
    }
}
