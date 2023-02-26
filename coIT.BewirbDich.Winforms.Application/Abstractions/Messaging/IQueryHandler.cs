using coIT.BewirbDich.Domain.Shared;
using MediatR;

namespace coIT.BewirbDich.Application.Abstractions.Messaging;

public interface IQueryHandler<TQuery, TResponse>
    : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}