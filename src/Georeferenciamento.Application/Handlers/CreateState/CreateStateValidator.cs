using FluentValidation;

namespace Georeferenciamento.Application.Handlers.CreateState;

public class CreateStateValidator : AbstractValidator<CreateStateCommand>
{
    public CreateStateValidator()
    {
        RuleFor(x => x.StatePostalCode)
            .NotEmpty()
            .NotNull();
        
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull();
        
        RuleFor(x => x.Capital)
            .NotEmpty()
            .NotNull();
    }
}