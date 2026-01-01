using Airbnb.Domain.Abstractions;
using MediatR;

namespace Airbnb.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}