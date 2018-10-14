using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Tournamentus.Api.Extensions;
using Tournamentus.Core.Tournamentus.Api;

namespace Tournamentus.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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