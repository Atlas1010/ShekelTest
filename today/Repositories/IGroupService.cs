using today.Entities;

namespace today.Repositories
{
    public interface IGroupService
    {
        public Task<List<Group>> GetGroupListAsync();
        public Task<IEnumerable<Group>> GetGroupByIdAsync(int Id);
        public Task<int> AddGroupAsync(Group group);
        public Task<int> UpdateGroupAsync(Group group);
        public Task<int> DeleteGroupAsync(int Id);
    }
}
