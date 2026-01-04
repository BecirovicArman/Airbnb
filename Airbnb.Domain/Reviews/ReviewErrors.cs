using Airbnb.Common.BuildingBlocks;
using Airbnb.Domain.Abstractions;

namespace Airbnb.Domain.Reviews;

public static class ReviewErrors
{
    public static readonly Error NotEligible = new(4001, 
        "The review is not eligible because the booking is not yet completed");
}