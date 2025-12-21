using Airbnb.Domain.Abstractions;
using MediatR;

namespace Airbnb.Application.Abstractions;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}