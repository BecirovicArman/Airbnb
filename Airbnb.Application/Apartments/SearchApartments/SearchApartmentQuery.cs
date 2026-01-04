using Airbnb.Domain.Abstractions;
using MediatR;

namespace Airbnb.Application.Apartments.SearchApartments;

public record SearchApartmentQuery(
    DateOnly StartDate,
    DateOnly EndDate) : IRequest<IReadOnlyList<ApartmentResponse>>;