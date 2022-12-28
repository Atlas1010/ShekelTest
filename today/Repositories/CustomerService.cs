using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using today.Data;
using today.Entities;

namespace today.Repositories
{
    public class CustomerService:ICustomerService
    {
        private readonly DbCustomercontext _dbCustomerContext;

        public CustomerService(DbCustomercontext dbCustomerContext)
        {
            _dbCustomerContext = dbCustomerContext;
        }

        public async Task<List<Customer>> GetCustomerListAsync()
        {
            return await _dbCustomerContext.Customers
                .FromSqlRaw<Customer>("GetCustomerList")
                .ToListAsync();
        }

        public async Task<IEnumerable<Customer>> GetCustomerByIdAsync(int CustomerId)
        {
            var param = new SqlParameter("@CustomerId", CustomerId);

            var customerDetails = await Task.Run(() => _dbCustomerContext.Customers
                            .FromSqlRaw(@"exec GetCustomerByID @CustomerId", param).ToListAsync());

            return customerDetails;
        }

        public async Task<int> AddCustomerAsync(Customer customer)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@name", customer.name));
            parameter.Add(new SqlParameter("@address", customer.address));
            parameter.Add(new SqlParameter("@phone", customer.phone));

            var result = await Task.Run(() => _dbCustomerContext.Database
           .ExecuteSqlRawAsync(@"exec AddNewCustomer @name, @address, @phone", parameter.ToArray()));

            return result;
        }

        public async Task<int> UpdateCustomertAsync(Customer customer)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@customerId", customer.customerId));
            parameter.Add(new SqlParameter("@name", customer.name));
            parameter.Add(new SqlParameter("@address", customer.address));
            parameter.Add(new SqlParameter("@phone", customer.phone));

            var result = await Task.Run(() => _dbCustomerContext.Database
            .ExecuteSqlRawAsync(@"exec UpdateCustomer @customerId, @name, @address, @phone", parameter.ToArray()));
            return result;
        }
        public async Task<int> DeleteCustomerAsync(int customerId)
        {
            return await Task.Run(() => _dbCustomerContext.Database.ExecuteSqlInterpolatedAsync($"DeleteCustomerByID {customerId}"));
        }
    }
}
