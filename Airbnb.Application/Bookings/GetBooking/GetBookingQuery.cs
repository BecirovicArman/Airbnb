using MediatR;

namespace Airbnb.Application.Bookings.GetBooking;

public sealed record GetBookingQuery(Guid BookingId) : IRequest<BookingResponse?>;