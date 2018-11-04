using FluentValidation.Validators;
using System.Linq;
using Tournamentus.Core.Data;

namespace Tournamentus.Core.Validation
{
    public class UserExistValidator : PropertyValidator
    {
        private TournamentusDb _db;

        public UserExistValidator(TournamentusDb db) : base("{PropertyName} value is invalid.")
        {
            _db = db;
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            var valid = false;

            var siteId = (int?)context.PropertyValue;

            if (siteId.HasValue)
            {
                var exists = _db.Users.Any(s => s.UserId == siteId.Value);

                if (exists)
                {
                    valid = true;
                }
            }

            return valid;
        }
    }
}
