using System.Security.Claims;
using System.Threading.Tasks;
using Tournamentus.Core.Validation;
using Tournamentus.Core.Model;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Tournamentus.Api.Security
{
    public class CustomJwtBearerEvents : JwtBearerEvents
    {
        public override async Task TokenValidated(TokenValidatedContext context)
        {
            var mediator = context.HttpContext.RequestServices.GetRequiredService<IMediator>();
            var httpContextAccessor = context.HttpContext.RequestServices.GetRequiredService<IHttpContextAccessor>();

            var externalUser = context.Principal;
            var email = externalUser.FindFirstValue("email");
            var userId = externalUser.FindFirstValue("NameIdentifier");

            var validateUserResponse = await mediator.Send(new UserValidate.Command
            {
                RoleId = 1,
                Email = email
            });

            if (validateUserResponse.IsValid)
            {
                var applicationUser = validateUserResponse.Result.ApplicationUser;

                AssignClaims(context.Principal, applicationUser);
                httpContextAccessor.HttpContext.User = context.Principal;
            }
        }

        private void AssignClaims(ClaimsPrincipal principal, User user)
        {
            var identity = principal.Identity as ClaimsIdentity;

            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
            // identity.AddClaim(new Claim(identity.RoleClaimType, user.Roles.Single().RoleId));
            // identity.AddClaim(new Claim(identity.NameClaimType, user.Name));
        }
    }
}
