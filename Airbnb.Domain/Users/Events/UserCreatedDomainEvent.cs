using Airbnb.Domain.Abstractions;

namespace Airbnb.Domain.Users.Events;

public sealed class UserCreatedDomainEvent(Guid UserId) : IDomainEvent
{
}