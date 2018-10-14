using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace Tournamentus.Core
{
    public class TournamentusResponse<T> : ITournamentusResponse<T>
            where T : new()
    {
        public TournamentusResponse()
        {
            Errors = Enumerable.Empty<ValidationFailure>();
        }

        public TournamentusResponse(IEnumerable<ValidationFailure> errors)
        {
            Errors = errors;
        }

        public bool IsValid
        {
            get
            {
                return !Errors.Any();
            }

            private set
            {
            }
        }

        public IEnumerable<ValidationFailure> Errors { get; set; }

        public T Result { get; set; } = new T();
    }

    public class TournamentusResponse : ITournamentusResponse
    {
        public TournamentusResponse()
        {
            Errors = Enumerable.Empty<ValidationFailure>();
        }

        public bool IsValid
        {
            get
            {
                return !Errors.Any();
            }

            private set
            {
            }
        }

        public IEnumerable<ValidationFailure> Errors { get; set; }
    }
}
