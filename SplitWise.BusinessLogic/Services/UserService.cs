using Microsoft.EntityFrameworkCore;
using SplitWise.BusinessLogic.Abstraction;
using SplitWise.Domain.Enteties;
using SplitWise.Infrastucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitWise.BusinessLogic.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        public UserService(splitwiseContext _db) : base(_db)
        {

        }

        public async Task<User> GetByName(string name)
        {
            return await _db.User.FirstOrDefaultAsync(el => el.Name == name);
        }

        public async Task<bool> IsUnique(string name)
        {
            var user = await GetByName(name);

            return user == null;
        }
    }
}
