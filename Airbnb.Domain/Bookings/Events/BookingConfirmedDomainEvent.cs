using Airbnb.Domain.Abstractions;

namespace Airbnb.Domain.Bookings.Events;

public record BookingConfirmedDomainEvent(Guid BookingId) : IDomainEvent;