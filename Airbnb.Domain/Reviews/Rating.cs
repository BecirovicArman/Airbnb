using Airbnb.Common.BuildingBlocks;
using Airbnb.Domain.Abstractions;

namespace Airbnb.Domain.Reviews;

public record Rating
{
    private Rating(int value) => Value = value;
    public int Value { get; set; }

    public static Rating Create(int value)
    {
        if (value < 1 || value > 5)
        {
            //return Result.Failure<Rating>(Invalid);
        }

        return new Rating(value);
    }

}