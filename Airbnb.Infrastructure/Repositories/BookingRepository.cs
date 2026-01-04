using Airbnb.Domain.Apartments;
using Airbnb.Domain.Bookings;

namespace Airbnb.Infrastructure.Repositories;

public class BookingRepository : IBookingRepository
{
    public Task<Booking?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public void Add(Booking booking)
    {
        throw new NotImplementedException();
    }

    public Task<Booking?> GetByApartmentIdAsync(Guid apartmentId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsOverlappingAsync(Apartment apartment, DateRange duration, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}