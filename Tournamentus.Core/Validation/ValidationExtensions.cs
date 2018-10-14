using Tournamentus.Core.Model;
using FluentValidation;
using FluentValidation.Results;
using FluentValidation.Validators;
using System.Collections.Generic;

namespace Tournamentus.Core.Validation
{
    public static class ValidationExtensions
    {
        public static void AddFailures(this CustomContext context, IList<ValidationFailure> failures)
        {
            foreach (var failure in failures)
            {
                context.AddFailure(failure);
            }
        }
    }
}
