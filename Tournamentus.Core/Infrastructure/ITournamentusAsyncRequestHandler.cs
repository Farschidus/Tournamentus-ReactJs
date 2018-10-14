using MediatR;

namespace Tournamentus.Core
{
    public interface ITournamentusAsyncRequestHandler<in TRequest, TResponse> : IAsyncRequestHandler<TRequest, TResponse>
        where TRequest : ITournamentusRequest<TResponse>
        where TResponse : ITournamentusResponse
    {
    }
}
