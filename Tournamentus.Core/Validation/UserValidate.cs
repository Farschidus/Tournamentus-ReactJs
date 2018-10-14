using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tournamentus.Core.Model;

namespace Tournamentus.Core.Validation
{
    public class UserValidate
    {
        public class Command : ITournamentusRequest<ITournamentusResponse<CommandResult>>
        {
            public int RoleId { get; set; }
            public string Email { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator(TournamentusDb db)
            {
                CascadeMode = CascadeMode.StopOnFirstFailure;

                RuleFor(command => command)
                    .CustomAsync(async (m, context, cancel) =>
                    {
                        var command = (Command)context.ParentContext.InstanceToValidate;
                        var failures = await UserExists(db, m.Email, nameof(command.Email));
                        context.AddFailures(failures);
                    })
                    .CustomAsync(async (m, context, cancel) =>
                    {
                        var command = (Command)context.ParentContext.InstanceToValidate;
                        var failures = await UserIsActive(db, m.Email, nameof(command.Email));
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

            private async Task<IList<ValidationFailure>> UserIsActive(TournamentusDb db, string email, string propertyName)
            {
                var failures = new List<ValidationFailure>();

                var userIsActive = await db.Users.AnyAsync(u => u.Email == email && u.LockoutEnabled == false);

                if (!userIsActive)
                {
                    failures.Add(new ValidationFailure(propertyName, $"User {email} is not active"));
                }

                return failures;
            }
        }

        public class CommandResult
        {
            public User ApplicationUser { get; set; }
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
                var response = new TournamentusResponse<CommandResult>();

                var user = await _db.Users.SingleAsync(u => u.Email == message.Email);

                var applicationUser = new User
                {
                    UserId = user.UserId,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                };

                response.Result.ApplicationUser = applicationUser;

                return response;
            }
        }
    }
}
