using Airbnb.Domain.Abstractions;

namespace Airbnb.Domain.Bookings.Events;

public record BookingCompletedDomainEvent(Guid BoqokingId) : IDomainEvent;