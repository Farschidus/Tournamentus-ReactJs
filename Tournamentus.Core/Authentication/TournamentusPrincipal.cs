using System.Security.Claims;

namespace Tournamentus.Core.Authentication
{
    public class TournamentusPrincipal : ClaimsPrincipal
    {
        public TournamentusPrincipal(ClaimsPrincipal principal) : base(principal)
        {
            var id = principal.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!string.IsNullOrEmpty(id))
            {
                if (int.TryParse(id, out int userId))
                {
                    UserId = userId;
                }
            }
        }

        public int UserId { get; set; }
    }
}
