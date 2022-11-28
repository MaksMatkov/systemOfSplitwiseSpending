using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SplitWise.BusinessLogic.Abstraction;
using SplitWise.BusinessLogic.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SplitWise.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService AuthenticationService;
        public readonly IOptions<AuthenticationConfiguration> options;

        public AuthenticationController(IOptions<AuthenticationConfiguration> _options, IAuthenticationService _AuthenticationService)
        {
            AuthenticationService = _AuthenticationService;
            options = _options;
        }

        [Route("login")]
        [HttpGet]
        public async Task<IActionResult> Login(string name, string password)
        {
            var User = await AuthenticationService.AuthenticateUser(name, password);

            if (User != null)
            {
                var AcToken = AuthenticationService.GetJWT(User, options);
                return Ok(new { access_token = AcToken });
            }

            return Unauthorized();
        }
    }
}
