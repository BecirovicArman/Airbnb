using Airbnb.Application.Abstractions.Email;
using Airbnb.Domain.Bookings;
using Airbnb.Domain.Bookings.Events;
using Airbnb.Domain.Users;
using MediatR;

namespace Airbnb.Application.Bookings.ReserveBooking;

internal sealed class BookingReservedDomainEventHandler(
    IBookingRepository bookingRepository,
    IUserRepository userRepository,
    IEmailService emailService)
    : INotificationHandler<BookingReservedDomainEvent>
{
    public async Task Handle(BookingReservedDomainEvent notification, CancellationToken cancellationToken)
    {
        var booking = await bookingRepository.GetByIdAsync(notification.BookingId, cancellationToken);

        if (booking == null)
        {
            return;
        }
        
        var user = await userRepository.GetByIdAsync(booking.UserId, cancellationToken);
        if (user == null)
        {
            return;
        }

        await emailService.SendAsync(user.Email,
            "Booking reserved",
            "You have 10 minutes to confirm this booking");
    }
}