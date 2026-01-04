using Airbnb.Domain.Apartments;

namespace Airbnb.Infrastructure.Repositories;

public class ApartmentRepository : IApartmentRepository
{
    public Task<Apartment?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}