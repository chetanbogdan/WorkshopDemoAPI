using FluentValidation;
using WorkshopDemoAPI.Entities;

namespace WorkshopDemoAPI.Validators;

public class CountryValidator : AbstractValidator<Country>
{
    public CountryValidator()
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