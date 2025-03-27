using FluentValidation;
using MediatR;
using ValidationException = FluentValidation.ValidationException;

namespace Georeferenciamento.Application.Common;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse> 
{
    private readonly IValidatorFactory _validatorFactory;

    public ValidationBehavior(IValidatorFactory validatorFactory)
    {
        _validatorFactory = validatorFactory;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var validator = _validatorFactory.GetValidator<TRequest>();
        
        if (validator != null)
        {
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                var errorMessages = validationResult.Errors
                    .Select(x => x.ErrorMessage)
                    .ToArray();
                
                throw new ValidationException(string.Join("\n", errorMessages));
            }
        }

        return await next();
    }
}