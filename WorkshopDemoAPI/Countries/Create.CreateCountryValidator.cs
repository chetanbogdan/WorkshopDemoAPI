using FastEndpoints;
using FluentValidation;

namespace WorkshopDemoAPI.Countries;

public class CreateCountryValidator : Validator<CreateCountryRequest>
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