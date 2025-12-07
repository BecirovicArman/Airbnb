using Airbnb.Domain.Abstractions;

namespace Airbnb.Domain.Bookings.Events;

public record BookingRejectedDomainEvent(Guid BookingId) : IDomainEvent;