using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Tournamentus.Core.Data;

namespace Tournamentus.Core.Api.Teams
{
    public class TeamList
    {
        public class Query : ITournamentusRequest<ITournamentusResponse<QueryResult>>
        {
        }

        public class QueryResult
        {
            public List<Team> Teams { get; set; } = new List<Team>();

            public class Team
            {
                public int Id { get; set; }
                public string Name { get; set; }
                public string IsoCode { get; set; }
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
                var response = new TournamentusResponse<QueryResult>();

                response.Result.Teams = await _db.Teams
                    .Select(x => new QueryResult.Team
                    {
                        Id = x.TeamId,
                        Name = x.Name,
                        IsoCode = x.Abbreviation.ToLower()
                    })
                    .ToListAsync();

                return response;
            }
        }
    }
}
