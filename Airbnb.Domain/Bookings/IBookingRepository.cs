using Airbnb.Domain.Apartments;

namespace Airbnb.Domain.Bookings;

public interface IBookingRepository
{
    Task<Booking?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    void Add(Booking booking);
    
    Task<Booking?> GetByApartmentIdAsync(Guid apartmentId, CancellationToken cancellationToken = default);
    
    Task<bool> IsOverlappingAsync(
        Apartment apartment,
        DateRange duration,
        CancellationToken cancellationToken = default);
}