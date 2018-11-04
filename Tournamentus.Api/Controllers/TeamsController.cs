using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tournamentus.Api.Extensions;
using Tournamentus.Core.Api.Teams;

namespace Tournamentus.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class TeamsController : Controller
    {
        private readonly IMediator _mediator;

        public TeamsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new TeamList.Query());

            return this.HandledResult(response);
        }
    }
}
