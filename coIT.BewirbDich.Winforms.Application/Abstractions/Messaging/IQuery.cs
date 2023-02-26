using coIT.BewirbDich.Domain.Shared;
using MediatR;

namespace coIT.BewirbDich.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}