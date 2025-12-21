using Airbnb.Domain.Abstractions;
using MediatR;

namespace Airbnb.Application.Abstractions;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}