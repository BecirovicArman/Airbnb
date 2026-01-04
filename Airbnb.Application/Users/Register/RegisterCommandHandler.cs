using Airbnb.Application.Abstractions.Clock;
using Airbnb.Common.Exceptions;
using Airbnb.Domain.Abstractions;
using Airbnb.Domain.Users;
using MediatR;

namespace Airbnb.Application.Users.Register;

public class RegisterCommandHandler(
    IUnitOfWork unitOfWork,
    IDateTimeProvider timeProvider,
    IUserRepository userRepository) : IRequestHandler<RegisterCommand, Guid>
{
    public async Task<Guid> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var existingUser = await userRepository.GetByEmailAsync(request.Email, cancellationToken);

        if (existingUser is not null)
        {
            throw new ConflictException(UserErrors.UserExists(request.Email));
        }

        var user = User.Create(request.Name, request.Email);
        
        userRepository.Add(user);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return user.Id;
    }
}