using MediatR;

namespace Tournamentus.Core
{
    public interface ITournamentusRequestHandler<in TRequest, out TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : ITournamentusRequest<TResponse>
        where TResponse : ITournamentusResponse
    {
    }
}
