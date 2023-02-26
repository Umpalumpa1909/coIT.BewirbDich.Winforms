using coIT.BewirbDich.Winforms.Domain.Shared;
using MediatR;

namespace coIT.BewirbDich.Winforms.Application.Abstractions.Messaging;

public interface IQueryHandler<TQuery, TResponse>
    : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}