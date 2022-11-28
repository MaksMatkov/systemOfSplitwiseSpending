using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SplitWise.BusinessLogic.Abstraction;
using SplitWise.BusinessLogic.Configurations;
using SplitWise.Domain.Enteties;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SplitWise.BusinessLogic.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        IUserService _us;

        public AuthenticationService(IUserService us)
        {
            this._us = us;
        }

        public async Task<User> AuthenticateUser(string name, string password)
        {
            var user = await _us.GetByName(name);

            return user;
        }

        public string GetJWT(User user, IOptions<AuthenticationConfiguration> options)
        {
            var authParams = options.Value;

            var SecKey = authParams.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(SecKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Name),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            };

            var token = new JwtSecurityToken(
                authParams.Issuer,
                authParams.Audience,
                claims,
                expires: DateTime.Now.AddSeconds(authParams.TokenLifetime),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
