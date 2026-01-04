using Airbnb.Application.Abstractions.Clock;
using Airbnb.Common.Exceptions;
using Airbnb.Domain.Abstractions;
using Airbnb.Domain.Apartments;
using Airbnb.Domain.Users;
using MediatR;

namespace Airbnb.Application.Bookings.ReserveBooking;

internal sealed class ReserveBookingCommandHandler(
    IUserRepository userRepository,
    IApartmentRepository apartmentRepository,
    IUnitOfWork unitOfWork,
    IDateTimeProvider dateTimeProvider)
    : IRequestHandler<ReserveBookingCommand, Guid>
{
    public async Task<Guid> Handle(ReserveBookingCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(request.UserId, cancellationToken);

        if (user is null)
        {
            throw new NotFoundException(UserErrors.NotFound(request.UserId.ToString()));
        }

        var apartment = await apartmentRepository.GetByIdAsync(request.ApartmentId, cancellationToken);

        if (apartment is null)
        {
            throw new NotFoundException(ApartmentErrors.NotFound(request.ApartmentId.ToString()));
        }
        
        var newBookingId = apartment.Book(request.StartDate, request.EndDate, user, dateTimeProvider.UtcNow);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return newBookingId;
    }
}