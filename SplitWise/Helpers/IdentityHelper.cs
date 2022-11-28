using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SplitWise.API.Helpers
{
    public class IdentityHelper
    {
        public static int GetSub(ClaimsPrincipal User)
        {
            var Id = 0;
            string IdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Int32.TryParse(IdStr, out Id);

            return Id;
        }
    }
}
