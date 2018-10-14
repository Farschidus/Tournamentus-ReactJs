using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Tournamentus.Core.Authentication;

namespace Tournamentus.Api.Security
{
    public class PrincipalProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PrincipalProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public TournamentusPrincipal Current()
        {
            if (_httpContextAccessor.HttpContext != null)
            {
                var defaultPrincipal = _httpContextAccessor.HttpContext.User;
                if (defaultPrincipal != null)
                {
                    var principal = MapToEasyCubePrincipal(defaultPrincipal);
                    return principal;
                }
                else
                {
                    return UnauthorizedPrincipal();
                }
            }
            else
            {
                return UnauthorizedPrincipal();
            }
        }

        private TournamentusPrincipal MapToEasyCubePrincipal(ClaimsPrincipal defaultPrincipal)
        {
            var principal = new TournamentusPrincipal(defaultPrincipal)
            {
                UserId = Convert.ToInt32(defaultPrincipal.FindFirstValue(ClaimTypes.NameIdentifier))
            };

            return principal;
        }

        private TournamentusPrincipal UnauthorizedPrincipal()
        {
            var defaultPrincipal = new ClaimsPrincipal();
            var identity = new ClaimsIdentity();
            identity.AddClaim(new Claim(identity.NameClaimType, "Unauthorized User"));

            defaultPrincipal.AddIdentity(identity);

            var principal = new TournamentusPrincipal(defaultPrincipal);

            return principal;
        }
    }
}
