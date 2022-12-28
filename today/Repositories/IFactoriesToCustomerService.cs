using Microsoft.AspNetCore.Mvc;
using today.Entities;

namespace today.Repositories
{
    public interface IFactoriesToCustomerService
    {
        public Task<List<FactoriesToCustomer>> GetFactoriesToCustomerListAsync();
        public Task<IEnumerable<FactoriesToCustomer>> GetFactoriesToCustomerByIdAsync(int Id);
        public Task<int> AddFactoriesToCustomerAsync(FactoriesToCustomer factoriesToCustomer);
        public Task<int> UpdateFactoriesToCustomerAsync(FactoriesToCustomer factoriesToCustomer);
        public Task<int> DeleteFactoriesToCustomerAsync(int Id);
        public Task<int> AddParams(string name, string address, string phone, int groupCode, int factoryCode);
        public Task<List<GroupCustomers>> GetGroupCustomersListAsync();
    }
}
