namespace Airbnb.Common.BuildingBlocks;

public abstract class BaseException : Exception
{
    protected BaseException(Error error, string? message = null, Exception? innerException = null)
        : base(message, innerException)
    {
        Error = error;
    }
    public Error Error { get; }
}