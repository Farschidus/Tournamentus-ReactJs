using Tournamentus.Api.Contracts;
using FluentValidation.Results;

namespace Tournamentus.Api.Extensions
{
    public static class ValidationFailureExtensions
    {
        public static ValidationFailureResult.Error ToValidationFailure(this ValidationFailure validationFailure)
        {
            return new ValidationFailureResult.Error()
            {
                PropertyName = validationFailure.PropertyName,
                ErrorMessage = validationFailure.ErrorMessage,
                AttemptedValue = validationFailure.AttemptedValue,
                ErrorCode = validationFailure.ErrorCode
            };
        }
    }
}
