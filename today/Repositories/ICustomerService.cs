using today.Entities;

namespace today.Repositories
{
    public interface ICustomerService
    {
        public Task<List<Customer>> GetCustomerListAsync();
        public Task<IEnumerable<Customer>> GetCustomerByIdAsync(int Id);
        public Task<int> AddCustomerAsync(Customer customer);
        public Task<int> UpdateCustomertAsync(Customer customer);
        public Task<int> DeleteCustomerAsync(int Id);
    }
}
