using MediatR;
using Microsoft.Extensions.Logging;

namespace Common.Behavior;

public class LoggerBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse> {
  private readonly ILogger<LoggerBehavior<TRequest, TResponse>> _logger;

  public LoggerBehavior(ILogger<LoggerBehavior<TRequest, TResponse>> logger) {
    _logger = logger;
  }

  public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken) {
    _logger.LogInformation("Logger ready...");
    return await next();
  }
}
