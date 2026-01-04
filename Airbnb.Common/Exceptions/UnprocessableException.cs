using Airbnb.Common.BuildingBlocks;

namespace Airbnb.Common.Exceptions;

public class UnprocessableException: BaseException
{
    public UnprocessableException(Error error) : base(error)
    {
    }
}