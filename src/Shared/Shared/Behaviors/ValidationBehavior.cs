using FluentValidation;
using MediatR;
using Shared.CQRS;

namespace Shared.Behaviors;

public class ValidationBehavior<TRequest, TRespond>
    (IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TRespond>
    where TRequest : ICommand<TRespond> {
    public async Task<TRespond> Handle(TRequest request, RequestHandlerDelegate<TRespond> next, CancellationToken cancellationToken) {
        var context = new ValidationContext<TRequest>(request);

        var validationResults = 
            await Task.WhenAll(validators.Select(v => v.ValidateAsync(context, cancellationToken)));
    
        var failures = validationResults
            .Where(r => r.Errors.Any())
            .SelectMany(r => r.Errors)
            .ToList();

        if (failures.Any()) {
            throw new ValidationException(failures);
        }

        return await next();
    }
}