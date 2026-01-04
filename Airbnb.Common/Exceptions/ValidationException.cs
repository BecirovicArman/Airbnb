namespace Airbnb.Common.Exceptions;

public class ValidationException(IEnumerable<ValidationError> errors) : Exception
{
    public IEnumerable<ValidationError> Errors { get; } = errors;
}