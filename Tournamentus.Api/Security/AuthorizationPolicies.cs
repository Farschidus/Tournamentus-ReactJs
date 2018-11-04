using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Tournamentus.Api.Security
{
    public class AuthorizationPolicies
    {
        public AuthorizationPolicy IsAuthenticated()
        {
            return new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
        }

        private AuthorizationPolicyBuilder NewPolicyBuilder()
        {
            var scheme = JwtBearerDefaults.AuthenticationScheme;
            return new AuthorizationPolicyBuilder(scheme);
        }
    }
}
