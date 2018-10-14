using Tournamentus.Api.Contracts;
using Tournamentus.Core;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Tournamentus.Api.Extensions
{
    public static class ControllerExtensions
    {
        public static IActionResult HandledResult<T>(this Controller controller, ITournamentusResponse<T> response, string redirectAction)
        {
            if (response.IsValid)
            {
                return new OkObjectResult(new
                {
                    redirect = controller.Url.Action(redirectAction)
                });
            }
            else
            {
                return new BadRequestObjectResult(GetValidationFailureResult(response));
            }
        }

        public static IActionResult HandledResult(this Controller controller, ITournamentusResponse response, string redirectAction)
        {
            if (response.IsValid)
            {
                return new OkObjectResult(new
                {
                    redirect = controller.Url.Action(redirectAction)
                });
            }
            else
            {
                return new BadRequestObjectResult(GetValidationFailureResult(response));
            }
        }

        public static IActionResult HandledResult<T>(this Controller controller, ITournamentusResponse<T> response)
        {
            if (response.IsValid)
            {
                return new OkObjectResult(response.Result);
            }
            else
            {
                return new BadRequestObjectResult(GetValidationFailureResult(response));
            }
        }

        public static IActionResult HandledResult(this Controller controller, ITournamentusResponse response)
        {
            if (response.IsValid)
            {
                return new NoContentResult();
            }
            else
            {
                return new BadRequestObjectResult(GetValidationFailureResult(response));
            }
        }

        private static ValidationFailureResult GetValidationFailureResult<T>(ITournamentusResponse<T> response)
        {
            var errors = response.Errors.Select(e => e.ToValidationFailure());
            var failureResult = new ValidationFailureResult(errors);

            return failureResult;
        }

        private static ValidationFailureResult GetValidationFailureResult(ITournamentusResponse response)
        {
            var errors = response.Errors.Select(e => e.ToValidationFailure());
            var failureResult = new ValidationFailureResult(errors);

            return failureResult;
        }
    }
}
