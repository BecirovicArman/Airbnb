using Airbnb.Application.Abstractions.Messaging;

namespace Airbnb.Application.Bookings.GetBooking;

public sealed record GetBookingQuery(Guid BookingId) : IQuery<BookingResponse>;