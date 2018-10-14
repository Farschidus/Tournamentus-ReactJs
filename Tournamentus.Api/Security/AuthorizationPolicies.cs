using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Tournamentus.Api.Security
{
    public class AuthorizationPolicies
    {
        public AuthorizationPolicy IsParticipant()
        {
            return NewPolicyBuilder()
                .RequireAuthenticatedUser()
                .RequireRole("Participant")
                .Build();
        }

        private AuthorizationPolicyBuilder NewPolicyBuilder()
        {
            var scheme = JwtBearerDefaults.AuthenticationScheme;
            return new AuthorizationPolicyBuilder(scheme);
        }
    }
}
