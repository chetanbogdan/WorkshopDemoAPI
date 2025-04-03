using FastEndpoints;
using FluentValidation;
using WorkshopDemoAPI.Application.Countries.Commands.CreateCountry;

namespace WorkshopDemoAPI.Countries;

public class CreateCountryValidator : Validator<CreateCountryCommand>
{
    public CreateCountryValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .MaximumLength(50);
        
        RuleFor(x => x.IsoCountryCode)
            .NotNull()
            .NotEmpty()
            .MaximumLength(2);
    }
}