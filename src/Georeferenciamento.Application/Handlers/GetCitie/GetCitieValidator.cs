using FluentValidation;

namespace Georeferenciamento.Application.Handlers.GetCitie;

public class GetCitieValidator : AbstractValidator<GetCitieCommand>
{
    public GetCitieValidator()
    {
        RuleFor(x => x.StatePostalCode)
            .NotEmpty()
            .NotNull();
        
        RuleFor(x => x.CityName)
            .NotEmpty()
            .NotNull();
    }
}