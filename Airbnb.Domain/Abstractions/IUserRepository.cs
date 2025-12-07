using Airbnb.Domain.Users;

namespace Airbnb.Domain.Abstractions;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    
    void Add(User user);
}