using Airbnb.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Airbnb.Infrastructure.Repositories;

public class UserRepository(ApplicationDbContext dbContext) : IUserRepository
{
    public Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return await dbContext.Set<User>()
            .SingleOrDefaultAsync(x => EF.Functions.ILike(email,
                    x.Email),
                cancellationToken: cancellationToken);
    }

    public void Add(User user)
    {
        dbContext.Set<User>().Add(user);
    }
}