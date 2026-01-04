using MediatR;
using FluentValidation;

namespace Airbnb.Application.Bookings.ReserveBooking;

public record ReserveBookingCommand(
    Guid ApartmentId,
    Guid UserId,
    DateOnly StartDate,
    DateOnly EndDate) : IRequest<Guid>;
    
public class ReserveBookingCommandValidator : AbstractValidator<ReserveBookingCommand>
{
    public ReserveBookingCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();

        RuleFor(c => c.ApartmentId).NotEmpty();
        
        RuleFor(c => c.StartDate).LessThan(c => c.EndDate);
    }
}