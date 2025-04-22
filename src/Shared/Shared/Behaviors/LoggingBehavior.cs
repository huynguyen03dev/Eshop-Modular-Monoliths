using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Shared.Behaviors;

public class LoggingBehavior<TRequest, TRespond>
    (ILogger<LoggingBehavior<TRequest, TRespond>> logger)
    : IPipelineBehavior<TRequest, TRespond> 
    where TRequest : notnull, IRequest<TRespond>
    where TRespond : notnull {
    public async Task<TRespond> Handle(TRequest request, RequestHandlerDelegate<TRespond> next, CancellationToken cancellationToken) {
        logger.LogInformation("[Start] Handle request={Request} - Respond={Respond} - RequestData={RequestData}",
            typeof(TRequest).Name, typeof(TRespond).Name, request);

        var timer = new Stopwatch();
        timer.Start();

        var respond = await next();

        timer.Stop();
        var timeTaken = timer.Elapsed;
        if (timeTaken.Seconds > 3) {
            logger.LogWarning("[PERFORMANCE] The request {Request} took {TimeTaken} seconds",
                typeof(TRequest).Name, timeTaken.Seconds);
        }

        logger.LogInformation("[End] Handle {Request} with {Respond}",
            typeof(TRequest).Name, typeof(TRespond).Name);
        
        return respond;
    }
}