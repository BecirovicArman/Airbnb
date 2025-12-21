using Airbnb.Domain.Abstractions;

namespace Airbnb.Domain.Reviews.Events;

public sealed record ReviewCreatedDomainEvent(Guid ReviewId) : IDomainEvent;