using Airbnb.Application.Abstractions.Messaging;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Airbnb.Application.Abstractions.Behaviors;

public class LoggingBehavior<TRequest, TResponse>(
    ILogger<TRequest> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IBaseCommand
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var name = request.GetType().Name;

        try
        {
            logger.LogInformation("Executing command {Command}", name);

            // if there are other behaviors -> go to them
            // if not -> execute the actual CommandHandler
            var result = await next();

            logger.LogInformation("Command {Command} processed successfully", name);

            return result;
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Command {Command} processing failed", name);

            throw;
        }
    }
}