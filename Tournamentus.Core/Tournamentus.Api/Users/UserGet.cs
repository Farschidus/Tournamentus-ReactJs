using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Tournamentus.Core.Model;

namespace Tournamentus.Core.Tournamentus.Api
{
    public class UserGet
    {
        public class Query : ITournamentusRequest<ITournamentusResponse<QueryResult>>
        {
            public int UserId { get; set; }
        }

        public class QueryValidator : AbstractValidator<Query>
        {
            public QueryValidator(TournamentusDb db)
            {
                //RuleFor(q => q.UserId).UserExists(db);
            }
        }

        public class QueryResult
        {
            public int UserId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public Timezone Timezone { get; set; }
            public string Picture { get; set; }
            public Points UserPoints { get; set; }

            public class Points
            {
                public int Perfect { get; set; }
                public int GoalDiff { get; set; }
                public int Correct { get; set; }
                public int Wrong { get; set; }
            }
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

                var points = new QueryResult.Points
                {
                    Perfect = 10,
                    GoalDiff = 7,
                    Correct = 5,
                    Wrong = 0
                };

                var user = _db.Users.AsNoTracking().FirstOrDefaultAsync(u => u.UserId == message.UserId).Result;

                result.UserId = user.UserId;
                result.FirstName = user.FirstName;
                result.LastName = user.LastName;
                result.Timezone = user.Timezone;
                result.UserPoints = points;
                
                var response = new TournamentusResponse<QueryResult>()
                {
                    Result = result
                };

                return response;
            }
        }
    }
}
