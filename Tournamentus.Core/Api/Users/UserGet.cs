using FluentValidation;
using FluentValidation.Results;
using Tournamentus.Core.Data;
using Tournamentus.Core.Validation;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Tournamentus.Core.Api.Users
{
    public class UserGet
    {
        public class Query : ITournamentusRequest<ITournamentusResponse<QueryResult>>
        {
            public int UserId { get; set; }

            public string Email { get; set; }
        }

        public class QueryValidator : AbstractValidator<Query>
        {
            public QueryValidator(TournamentusDb db)
            {
                RuleFor(q => q).CustomAsync(async (m, context, cancel) =>
                {
                    var command = (Query)context.ParentContext.InstanceToValidate;
                    var failures = await UserExists(db, m.Email, nameof(command.Email));
                    context.AddFailures(failures);
                });
            }

            private async Task<IList<ValidationFailure>> UserExists(TournamentusDb db, string email, string propertyName)
            {
                var failures = new List<ValidationFailure>();

                var userExists = await db.Users.AnyAsync(u => u.Email == email);

                if (!userExists)
                {
                    failures.Add(new ValidationFailure(propertyName, $"User {email} has not been created in Tournamentus"));
                }

                return failures;
            }
        }

        public class QueryResult
        {
            public int UserId { get; set; }
            public string Email { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        public class QueryHandler : ITournamentusAsyncRequestHandler<Query, ITournamentusResponse<QueryResult>>
        {
            private readonly TournamentusDb _db;

            public QueryHandler(TournamentusDb db)
            {
                _db = db;
            }

            public async Task<ITournamentusResponse<QueryResult>> Handle(Query message)
            {
                var result = new QueryResult();

                var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == message.Email);

                result.UserId = user.UserId;
                result.Email = user.Email;
                result.FirstName = user.FirstName;
                result.LastName = user.LastName;

                var response = new TournamentusResponse<QueryResult>()
                {
                    Result = result
                };

                return response;
            }
        }
    }
}
