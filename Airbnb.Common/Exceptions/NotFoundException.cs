using Airbnb.Common.BuildingBlocks;

namespace Airbnb.Common.Exceptions;

public sealed class NotFoundException : BaseException
{
    public NotFoundException(Error error) : base(error)
    {
    }
}