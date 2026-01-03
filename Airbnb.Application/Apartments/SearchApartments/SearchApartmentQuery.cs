using Airbnb.Application.Abstractions.Messaging;

namespace Airbnb.Application.Apartments.SearchApartments;

public record SearchApartmentQuery(
    DateOnly StartDate,
    DateOnly EndDate) : IQuery<IReadOnlyList<ApartmentResponse>>;