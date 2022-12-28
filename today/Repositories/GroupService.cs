using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using today.Data;
using today.Entities;

namespace today.Repositories
{
    public class GroupService : IGroupService
    {
        private readonly DbGroupContext _dbGroupContext;

        public GroupService(DbGroupContext dbGroupContext)
        {
            _dbGroupContext = dbGroupContext;
        }

        public async Task<List<Group>> GetGroupListAsync()
        {
            return await _dbGroupContext.Groups
                .FromSqlRaw<Group>("GetGroupList")
                .ToListAsync();
        }

        public async Task<IEnumerable<Group>> GetGroupByIdAsync(int GroupCode)
        {
            var param = new SqlParameter("@groupCode", GroupCode);

            var GroupDetails = await Task.Run(() => _dbGroupContext.Groups
                            .FromSqlRaw(@"exec GetGroupByID @groupCode", param).ToListAsync());

            return GroupDetails;
        }

        public async Task<int> AddGroupAsync(Group group)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@groupName", group.groupName));

            var result = await Task.Run(() => _dbGroupContext.Database
           .ExecuteSqlRawAsync(@"exec AddNewGroup @groupName", parameter.ToArray()));

            return result;
        }

        public async Task<int> UpdateGroupAsync(Group group)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@groupCode", group.groupCode));
            parameter.Add(new SqlParameter("@groupName", group.groupName));

            var result = await Task.Run(() => _dbGroupContext.Database
            .ExecuteSqlRawAsync(@"exec UpdateGroup @groupCode, @groupName", parameter.ToArray()));
            return result;
        }
        public async Task<int> DeleteGroupAsync(int groupCode)
        {
            return await Task.Run(() => _dbGroupContext.Database.ExecuteSqlInterpolatedAsync($"DeleteGroupByID {groupCode}"));
        }
    }
}
