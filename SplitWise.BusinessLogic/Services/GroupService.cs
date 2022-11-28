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

        public async Task<User> AddFirstUserToGroup(int userID, int groupID)
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

            return user;
        }

        public async Task<User> AddNewUserToGroup(int inviterUserId, int userID, int groupID)
        {
            if(!await IsMemberOfGroup(inviterUserId, groupID))
                throw new ForbiddenException("Only group members can add users to this group!");

            return await AddFirstUserToGroup(userID, groupID);
        }

        //TODO: replace to stored procedure.
        #region toProcedure
        public async Task<List<User>> GetGroupMembersAsync(int groupID, int reciverUserId)
        {
            if (!await IsMemberOfGroup(reciverUserId, groupID))
                throw new ForbiddenException("Not allow!");
            var group = await GetByKeysAsync(groupID);

            var users = _db.UserGroups.Where(el => el.GroupId == groupID)
                .Include(el => el.User)
                .Select(el => el.User).ToListAsync();

            return await users;
        }

        public async Task<List<Group>> GetAllByUserAsync(int userId)
        {
            return await _db.UserGroups.Where(el => el.UserId == userId)
                .Include(el => el.Group)
                .Select(el => el.Group).ToListAsync();
        }


        #endregion

        public async Task<bool> IsMemberOfGroup(int userID, int groupID)
        {
            var value = await _db.UserGroups.Where(el => el.UserId == userID && el.GroupId == groupID).FirstOrDefaultAsync();
            return value != null && value.UserId == userID;
        }

        public async Task<Group> GetSecureAsync(int groupId, int userId)
        {
            if (!await IsMemberOfGroup(userId, groupId))
                throw new ForbiddenException("Only group members can add users to this group!");

            return await GetByKeysAsync(groupId);
        }
    }
}
