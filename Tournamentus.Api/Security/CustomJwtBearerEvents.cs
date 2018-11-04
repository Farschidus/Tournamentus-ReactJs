using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Tournamentus.Core.Authentication;
using Tournamentus.Core.Data;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.IdentityModel.Tokens.Jwt;

namespace Tournamentus.Api.Security
{
    public class CustomJwtBearerEvents : JwtBearerEvents
    {
        public override async Task TokenValidated(TokenValidatedContext context)
        {
            var mediator = context.HttpContext.RequestServices.GetRequiredService<IMediator>();
            var httpContextAccessor = context.HttpContext.RequestServices.GetRequiredService<IHttpContextAccessor>();
            var accessToken = context.SecurityToken as JwtSecurityToken;

            if (accessToken != null)
            {
                var identity = context.Principal.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    identity.AddClaim(new Claim("access_token", accessToken.RawData));
                }
            }

            var externalUser = context.Principal;
            var email = externalUser.FindFirstValue("email");
            var validateUserResponse = await mediator.Send(new UserValidate.Command
            {
                Email = email
            });

            if (validateUserResponse.IsValid)
            {
                var user = validateUserResponse.Result.User;

                AssignClaims(context.Principal, user);
                httpContextAccessor.HttpContext.User = context.Principal;
            }
        }

        private void AssignClaims(ClaimsPrincipal principal, User user)
        {
            var identity = principal.Identity as ClaimsIdentity;

            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
            //identity.AddClaim(new Claim(identity.RoleClaimType, user.UserRoles.Single().Role));
            identity.AddClaim(new Claim(identity.NameClaimType, user.FirstName));
        }
    }
}
