using MediatR;

namespace Tournamentus.Core
{
    public interface ITournamentusRequest<out TResponse> : IRequest<TResponse>
        where TResponse : ITournamentusResponse
    {
    }
}
