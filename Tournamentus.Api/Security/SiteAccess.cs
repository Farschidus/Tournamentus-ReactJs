using Tournamentus.Core.Authentication;
using Tournamentus.Core.Data;
using Microsoft.AspNetCore.Authorization;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Tournamentus.Api.Security
{
    public class SiteAccess
    {
        public class Requirement : IAuthorizationRequirement
        {

        }

        public class Handler : AuthorizationHandler<Requirement, int>
        {
            private readonly TournamentusPrincipal _principal;
            private readonly TournamentusDb _db;

            public Handler(TournamentusPrincipal principal, TournamentusDb db)
            {
                _principal = principal;
                _db = db;
            }

            protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, Requirement requirement, int siteId)
            {
                var hasAccess = await _db.SiteUsers.AnyAsync(su => su.UserId == _principal.UserId && su.SiteId == siteId);

                if (hasAccess)
                {
                    context.Succeed(requirement);
                }

                return;
            }
        }
    }
}
