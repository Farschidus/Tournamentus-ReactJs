using FluentValidation;
using FluentValidation.Results;
using Tournamentus.Core.Authentication;
using Tournamentus.Core.Data;
using Tournamentus.Core.Validation;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Tournamentus.Core.Api.Users
{
    public class UserAuth
    {
        public class Query : ITournamentusRequest<ITournamentusResponse<QueryResult>>
        {
            public string Email { get; set; }

            public string Password { get; set; }
        }

        public class QueryValidator : AbstractValidator<Query>
        {
            public QueryValidator(TournamentusDb db)
            {
                RuleFor(q => q.Email).NotEmpty();
                RuleFor(q => q.Password).NotEmpty();
                RuleFor(q => q).CustomAsync(async (m, context, cancel) =>
                {
                    var command = (Query)context.ParentContext.InstanceToValidate;
                    var failures = await PasswordCheck(db, m.Email, m.Password);
                    context.AddFailures(failures);
                });
            }

            private async Task<IList<ValidationFailure>> PasswordCheck(TournamentusDb db, string email, string password)
            {
                var failures = new List<ValidationFailure>();

                var user = await db.Users.FirstOrDefaultAsync(x => x.Email == email);
                if (user.PasswordHash.Length != 64)
                {
                    failures.Add(new ValidationFailure("Credentials", $"Invalid length of password hash (64 bytes expected)."));
                }

                if (user.PasswordSalt.Length != 128)
                {
                    failures.Add(new ValidationFailure("Credentials", $"Invalid length of password salt(128 bytes expected)."));
                }

                if (!AuthServices.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                {
                    failures.Add(new ValidationFailure("Credentials", $"username or password is not correct!"));
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
            public string Token { get; set; }
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
                var user = await _db.Users.SingleOrDefaultAsync(x => x.Email == message.Email);

                var token = AuthServices.GenerateToken(user.UserId);
                var result = new QueryResult
                {
                    UserId = user.UserId,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Token = token
                };

                var response = new TournamentusResponse<QueryResult>()
                {
                    Result = result
                };

                return response;
            }
        }
    }
}
