using Airbnb.Domain.Abstractions;

namespace Airbnb.Domain.Bookings.Events;

public record BookingReservedDomainEvent(Guid BookingId) : IDomainEvent;