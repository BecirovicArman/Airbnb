using Airbnb.Common.BuildingBlocks;
using Airbnb.Domain.Abstractions;

namespace Airbnb.Domain.Bookings;

public static class BookingErrors
{
    public static Error NotFound(string bookingId) => new(
        3001,
        $"The booking with ID '{bookingId}' was not found.");
    
    public static Error NotReserved(string bookingId) => new(
        3003,
        $"The booking '{bookingId}' is not in a reserved (pending) state.");

    public static Error NotConfirmed(string bookingId) => new(
        3004,
        $"The booking '{bookingId}' is not confirmed.");

    public static Error AlreadyStarted(string bookingId) => new(
        3005,
        $"The booking '{bookingId}' has already started.");
}