using SplitWise.Domain.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitWise.BusinessLogic.Abstraction
{
    public interface IGroupService : IBaseServise<Group>
    {
        public Task<bool> AddFirstUserToGroup(int userID, int groupID);
        public Task<bool> AddNewUserToGroup(int inviterUserId, int userID, int groupID);

        public Task<bool> IsMemberOfGroup(int userID, int groupID);
    }
}
