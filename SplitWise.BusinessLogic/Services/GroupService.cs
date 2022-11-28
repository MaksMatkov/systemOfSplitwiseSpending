using Microsoft.EntityFrameworkCore;
using SplitWise.BusinessLogic.Abstraction;
using SplitWise.BusinessLogic.CustomExceptions;
using SplitWise.Domain.Enteties;
using SplitWise.Infrastucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitWise.BusinessLogic.Services
{
    public class GroupService : BaseService<Group>, IGroupService
    {
        public GroupService(splitwiseContext _db) : base(_db) { }

        public async Task<bool> AddUserToGroup(int userID, int groupID)
        {
            var group = await GetByKeysAsync(groupID);
            if (group == null)
                throw new EntityNotFoundException("The Group cannot be found.", groupID);
            var user = await _db.User.FindAsync(userID);
            if (user == null)
                throw new EntityNotFoundException("The User cannot be found.", userID);

            var item = new UserGroup() { GroupId = groupID, UserId = userID };

            (group.UserGroups as List<UserGroup>).Add(item);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> IsMemberOfGroup(int userID, int groupID)
        {
            var value = await _db.UserGroups.Where(el => el.UserId == userID && el.GroupId == groupID).FirstOrDefaultAsync();
            return value != null && value.UserId == userID;
        }
    }
}
