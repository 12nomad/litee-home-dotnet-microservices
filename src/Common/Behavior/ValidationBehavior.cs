using Common.CQRS;
using FluentValidation;
using MediatR;

namespace Common.Behavior;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : ICommand<TResponse> {
  private readonly IEnumerable<IValidator<TRequest>> _validators;
  public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators) {
    _validators = validators;
  }

  public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken) {
    if (!_validators.Any()) {
      return await next();
    }

    var context = new ValidationContext<TRequest>(request);

    var validationResults =
        await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));

    var errors =
        validationResults
        .Where(r => r.Errors.Any())
        .SelectMany(r => r.Errors)
        .ToList();

    if (errors.Any())
      throw new ValidationException(errors);

    return await next();
  }
}
