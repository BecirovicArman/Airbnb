using FluentValidation;
using MediatR;

namespace Airbnb.Application.Users.Register;

public record RegisterCommand(string Name, string Email): IRequest<Guid>;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required");
        
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .WithMessage("Email is required");
    }
}