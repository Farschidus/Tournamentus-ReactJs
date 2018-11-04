using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tournamentus.Api.Extensions;
using Tournamentus.Core.Api.Users;
using System.Threading.Tasks;

namespace Tournamentus.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]/[action]")]
    public class UsersController : Controller
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody]UserAuth.Query query)
        {
            var response = await _mediator.Send(query);

            return this.HandledResult(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]UserCreate.Command command)
        {
            var response = await _mediator.Send(command);

            return this.HandledResult(response);
        }
    }
}
