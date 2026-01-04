using Airbnb.Common.Exceptions;
using Microsoft.AspNetCore.Http;

namespace Airbnb.Infrastructure.ExceptionHandlers;

public class ConflictExceptionHandler : BaseExceptionHandler<ConflictException>
{
    public ConflictExceptionHandler() : base(StatusCodes.Status409Conflict)
    {
    }
}