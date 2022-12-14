using SplitWise.Domain.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitWise.BusinessLogic.Abstraction
{
    public interface IUserService : IBaseServise<User>
    {
        public Task<bool> IsUnique(string name);

        public Task<User> GetByName(string name);
    }
}
