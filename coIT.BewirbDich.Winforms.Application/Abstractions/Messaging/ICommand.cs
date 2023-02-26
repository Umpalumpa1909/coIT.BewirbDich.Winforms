using coIT.BewirbDich.Domain.Shared;
using MediatR;

namespace coIT.BewirbDich.Application.Abstractions.Messaging;

public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}