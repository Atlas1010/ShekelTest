using today.Entities;

namespace today.Repositories
{
    public interface IFactoryService
    {
        public Task<List<Factory>> GetFactoryListAsync();
        public Task<IEnumerable<Factory>> GetFactoryByIdAsync(int Id);
        public Task<int> AddFactoryAsync(Factory factory);
        public Task<int> UpdateFactoryAsync(Factory factory);
        public Task<int> DeleteFactoryAsync(int Id);
    }
}
