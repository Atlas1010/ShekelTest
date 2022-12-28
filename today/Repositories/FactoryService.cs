using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using today.Data;
using today.Entities;

namespace today.Repositories
{
    public class FactoryService:IFactoryService
    {
        private readonly DbFactoryContext _dbFactoryContext;

        public FactoryService(DbFactoryContext dbFactoryContext)
        {
            _dbFactoryContext = dbFactoryContext;
        }

        public async Task<List<Factory>> GetFactoryListAsync()
        {
            return await _dbFactoryContext.Factories
                .FromSqlRaw<Factory>("GetFactoryList")
                .ToListAsync();
        }

        public async Task<IEnumerable<Factory>> GetFactoryByIdAsync(int factoryCode)
        {
            var param = new SqlParameter("@factoryCode", factoryCode);

            var FactoryDetails = await Task.Run(() => _dbFactoryContext.Factories
                            .FromSqlRaw(@"exec GetFactoryByID @factoryCode", param).ToListAsync());

            return FactoryDetails;
        }

        public async Task<int> AddFactoryAsync(Factory factory)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@factoryName", factory.factoryName));
            parameter.Add(new SqlParameter("@groupCode", factory.groupCode));

            var result = await Task.Run(() => _dbFactoryContext.Database
           .ExecuteSqlRawAsync(@"exec AddNewFactory @factoryName, @groupCode", parameter.ToArray()));

            return result;
        }

        public async Task<int> UpdateFactoryAsync(Factory factory)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@factoryCode", factory.factoryCode));
            parameter.Add(new SqlParameter("@factoryName", factory.factoryName));
            parameter.Add(new SqlParameter("@groupCode", factory.groupCode));

            var result = await Task.Run(() => _dbFactoryContext.Database
            .ExecuteSqlRawAsync(@"exec UpdateFactory @factoryCode, @factoryName, @groupCode", parameter.ToArray()));
            return result;
        }
        public async Task<int> DeleteFactoryAsync(int factoryCode)
        {
            return await Task.Run(() => _dbFactoryContext.Database.ExecuteSqlInterpolatedAsync($"DeleteFactoryByID {factoryCode}"));
        }
    }
}
