using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Application.Common.Behaviours
{
    public class RequestPerformanceBehaviour<TRequest, TResponse>(ILogger<TRequest> logger)
        : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        private readonly Stopwatch _timer = new();

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _timer.Start();

            var response = await next();

            _timer.Stop();

            if (_timer.ElapsedMilliseconds <= 500)
                return response;

            var name = typeof(TRequest).Name;

            logger.LogWarning("LabRat long running request: {Name} ({ElapsedMilliseconds} milliseconds) {@Request}",
                name,
                _timer.ElapsedMilliseconds,
                request);

            return response;
        }
    }
}