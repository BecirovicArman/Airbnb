using System.Text.Json;
using Airbnb.Common.BuildingBlocks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Airbnb.Infrastructure.ExceptionHandlers;

public abstract class BaseExceptionHandler<TException> : IExceptionHandler 
    where TException : BaseException
{
    private readonly int _statusCode;
    
    private static readonly JsonSerializerOptions JsonSerializerOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };
    
    protected BaseExceptionHandler(int statusCode)
    {
        _statusCode = statusCode;
    }
    
    private static Task HandleProblemDetailsAsync(HttpContext context, ProblemDetails details)
    {
        var responseContent = JsonSerializer.Serialize(details, JsonSerializerOptions);

        context.Response.StatusCode = details.Status!.Value;
        context.Response.ContentType = "application/json";
        return context.Response.WriteAsync(responseContent);
    }
    
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception,
        CancellationToken cancellationToken)
    {
        if (exception is not TException baseException)
        {
            return false;
        }

        var problemDetails = new ProblemDetails
        {
            Title = baseException.Error.Code.ToString(),
            Status = _statusCode,
            Detail = baseException.Error.Description
        };

        await HandleProblemDetailsAsync(httpContext, problemDetails);
        return true;
    }
}