using FluentValidation;
using MediatR;

namespace JobPortal.Application.Common.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);
            var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
            var failures = validationResults
                            .SelectMany(r => r.Errors)
                            .Where(f => f != null)
                            .GroupBy(
                                x => x.PropertyName,
                                x => x.ErrorMessage
                            )
                            .ToDictionary(
                                g => g.Key,
                                g => g.ToArray()
                            );
            if (failures.Any())
            {
                throw new JobPortal.Application.Exceptions.ValidationException(failures);
            }
            return await next();
        }
    }
}
