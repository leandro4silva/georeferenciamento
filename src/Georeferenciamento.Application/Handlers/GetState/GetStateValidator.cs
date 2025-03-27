using FluentValidation;

namespace Georeferenciamento.Application.Handlers.GetState;

public class GetStateValidator : AbstractValidator<GetStateCommand> 
{
    public GetStateValidator()
    {
        RuleFor(x => x.StatePostalCode)
            .NotEmpty()
            .NotNull();
    }
}