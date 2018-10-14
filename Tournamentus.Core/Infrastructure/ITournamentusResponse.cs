using System.Collections.Generic;
using FluentValidation.Results;

namespace Tournamentus.Core
{
    public interface ITournamentusResponse
    {
        IEnumerable<ValidationFailure> Errors { get; set; }

        bool IsValid { get; }
    }

    public interface ITournamentusResponse<T> : ITournamentusResponse
    {
        T Result { get; set; }
    }
}