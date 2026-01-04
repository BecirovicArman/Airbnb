using Airbnb.Application.Abstractions.Clock;

namespace Airbnb.Infrastructure.Clock;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}