using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using today.Data;
using today.Entities;

namespace today.Repositories
{
    public class FactoriesToCustomerService : IFactoriesToCustomerService
    {
        private readonly DbFactoriesToCustomerContext _dbFactoriesToCustomerContext;

        public FactoriesToCustomerService(DbFactoriesToCustomerContext dbFactoriesToCustomerContext)
        {
            _dbFactoriesToCustomerContext = dbFactoriesToCustomerContext;
        }

        public async Task<List<FactoriesToCustomer>> GetFactoriesToCustomerListAsync()
        {
            return await _dbFactoriesToCustomerContext.FactoriesToCustomer
                .FromSqlRaw<FactoriesToCustomer>("GetFactoriesToCustomerList")
                .ToListAsync();
        }

        public async Task<IEnumerable<FactoriesToCustomer>> GetFactoriesToCustomerByIdAsync(int id)
        {
            var param = new SqlParameter("@id", id);

            var FactoriesToCustomerDetails = await Task.Run(() => _dbFactoriesToCustomerContext.FactoriesToCustomer
                            .FromSqlRaw(@"exec GetFactoriesToCustomerByID @id", param).ToListAsync());

            return FactoriesToCustomerDetails;
        }

        public async Task<int> AddFactoriesToCustomerAsync(FactoriesToCustomer FactoriesToCustomer)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@groupCode", FactoriesToCustomer.groupCode));
            parameter.Add(new SqlParameter("@factoryCode", FactoriesToCustomer.factoryCode));
            parameter.Add(new SqlParameter("@customerId", FactoriesToCustomer.customerId));

            var result = await Task.Run(() => _dbFactoriesToCustomerContext.Database
           .ExecuteSqlRawAsync(@"exec AddNewFactoriesToCustomer @groupCode, @factoryCode, @customerId", parameter.ToArray()));

            return result;
        }

        public async Task<int> UpdateFactoriesToCustomerAsync(FactoriesToCustomer FactoriesToCustomer)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@id", FactoriesToCustomer.id));
            parameter.Add(new SqlParameter("@groupCode", FactoriesToCustomer.groupCode));
            parameter.Add(new SqlParameter("@factoryCode", FactoriesToCustomer.factoryCode));
            parameter.Add(new SqlParameter("@customerId", FactoriesToCustomer.customerId));

            var result = await Task.Run(() => _dbFactoriesToCustomerContext.Database
            .ExecuteSqlRawAsync(@"exec UpdateFactoriesToCustomer @id, @groupCode, @factoryCode, @customerId", parameter.ToArray()));
            return result;
        }
        public async Task<int> DeleteFactoriesToCustomerAsync(int id)
        {
            return await Task.Run(() => _dbFactoriesToCustomerContext.Database.ExecuteSqlInterpolatedAsync($"DeleteFactoriesToCustomerByID {id}"));
        }
        //1
        public async Task<int> AddParams(string name, string address, string phone, int groupCode, int factoryCode)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@name", name));
            parameter.Add(new SqlParameter("@address", address));
            parameter.Add(new SqlParameter("@phone", phone));
            parameter.Add(new SqlParameter("@groupCode", groupCode));
            parameter.Add(new SqlParameter("@factoryCode", factoryCode));

            var result = await Task.Run(() => _dbFactoriesToCustomerContext.Database
           .ExecuteSqlRawAsync(@"exec AddParams @name, @address, @phone, @groupCode, @factoryCode", parameter.ToArray()));

            return result;
        }
        public async Task<List<GroupCustomers>> GetGroupCustomersListAsync()
        {
            return await Task.Run(() => _dbFactoriesToCustomerContext.GroupCustomers
                             .FromSqlRaw(@"exec GroupCustomers").ToListAsync());

        }


    }
}
