using Airbnb.Domain.Abstractions;

namespace Airbnb.Domain.Bookings.Events;

public record BookingCancelledDomainEvent(Guid BookingId) : IDomainEvent;