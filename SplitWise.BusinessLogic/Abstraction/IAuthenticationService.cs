using Microsoft.Extensions.Options;
using SplitWise.BusinessLogic.Configurations;
using SplitWise.Domain.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitWise.BusinessLogic.Abstraction
{
    public interface IAuthenticationService
    {
        public Task<User> AuthenticateUser(string name, string password);
        public string GetJWT(User user, IOptions<AuthenticationConfiguration> options);
    }
}
