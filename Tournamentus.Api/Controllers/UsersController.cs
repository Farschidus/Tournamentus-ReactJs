using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tournamentus.Api.Extensions;
using Tournamentus.Core.Tournamentus.Api;

namespace Tournamentus.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new UserGet.Query());

            return this.HandledResult(response);
        }
    }
}