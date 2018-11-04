using FluentValidation.Results;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace Tournamentus.Core.Eseye
{
    public static class ITournamentusResponseExtensions
    {
        public static async void AddEseyeErrors(this ITournamentusResponse result, HttpResponseMessage response)
        {
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                var errors = new List<ValidationFailure> { new ValidationFailure("Not Found", "API down or endpoint not found") { ErrorCode = "RetryMessage" } };
                result.Errors = errors;

                return;
            }

            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == HttpStatusCode.InternalServerError || response.StatusCode == HttpStatusCode.BadRequest)
            {
                result.AddInternalServerEseyeErrors(responseContent);
            }
            else
            {
                result.AddEseyeErrorsFromResponse(responseContent);
            }
        }

        public static void AddEseyeErrors(this ITournamentusResponse result, string errorCode, string message)
        {
            var errorResponse = new List<ValidationFailure>();

            errorResponse.Add(new ValidationFailure(errorCode, message));

            result.Errors = errorResponse;
        }

        public static void AddInternalServerEseyeErrors(this ITournamentusResponse result, string responseContent)
        {
            var errors = new List<ValidationFailure> { new ValidationFailure("Internal Server Error", responseContent) };
            result.Errors = errors;
        }

        private static void AddEseyeErrorsFromResponse(this ITournamentusResponse result, string responseContent)
        {
            dynamic errors = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(responseContent);
            var errorResponse = new List<ValidationFailure>();

            foreach (var field in errors)
            {
                foreach (var error in field.Value)
                {
                    errorResponse.Add(new ValidationFailure(field.Key, error));
                }
            }

            result.Errors = errorResponse;
        }
    }
}
