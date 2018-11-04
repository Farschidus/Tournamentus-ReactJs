using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Tournamentus.Core.Authentication;
using Tournamentus.Core.Data;
using Tournamentus.Core.Validation;

namespace Tournamentus.Core.Api.Users
{
    public class UserCreate
    {
        public class Command : ITournamentusRequest<ITournamentusResponse<CommandResult>>
        {
            public string Email { get; set; }
            public string Password { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator(TournamentusDb db)
            {
                RuleFor(c => c.Password).NotEmpty();
                RuleFor(q => q).CustomAsync(async (m, context, cancel) =>
                {
                    var command = (Command)context.ParentContext.InstanceToValidate;
                    var failures = await UserExists(db, m.Email, nameof(command.Email));
                    context.AddFailures(failures);
                });
            }

            private async Task<IList<ValidationFailure>> UserExists(TournamentusDb db, string email, string propertyName)
            {
                var failures = new List<ValidationFailure>();

                var userExists = await db.Users.AnyAsync(u => u.Email == email);

                if (userExists)
                {
                    failures.Add(new ValidationFailure(propertyName, $"{email} is already taken!"));
                }

                return failures;
            }
        }

        public class CommandResult
        {
            public int UserId { get; set; }
            public string Email { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        public class CommandHandler : ITournamentusAsyncRequestHandler<Command, ITournamentusResponse<CommandResult>>
        {
            private readonly TournamentusDb _db;

            public CommandHandler(TournamentusDb db)
            {
                _db = db;
            }

            public async Task<ITournamentusResponse<CommandResult>> Handle(Command message)
            {
                byte[] passwordHash, passwordSalt;
                AuthServices.CreatePasswordHash(message.Password, out passwordHash, out passwordSalt);

                var newUser = new User
                {
                    Email = message.Email,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    FirstName = message.FirstName,
                    LastName = message.LastName,
                    LockoutEnabled = true
                };

                _db.Users.Add(newUser);
                await _db.SaveChangesAsync();

                var result = new CommandResult()
                {
                    UserId = newUser.UserId,
                    Email = newUser.Email,
                    FirstName = newUser.FirstName,
                    LastName = newUser.LastName
                };

                var response = new TournamentusResponse<CommandResult>()
                {
                    Result = result
                };

                return response;
            }
        }
    }
}
