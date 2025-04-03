using FastEndpoints;
using FluentValidation;

namespace WorkshopDemoAPI.Countries;

public class GetCountryByIdValidator : Validator<GetCountryByIdRequest>
{
    public GetCountryByIdValidator()
    {
        RuleFor(x => x.CountryId)
            .NotNull()
            .NotEmpty();
    }
}