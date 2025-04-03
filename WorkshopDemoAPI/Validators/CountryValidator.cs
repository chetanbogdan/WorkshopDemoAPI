using FluentValidation;
using WorkshopDemoAPI.Entities;

namespace WorkshopDemoAPI.Validators;

public class CountryValidator : AbstractValidator<Country>
{
    public CountryValidator()
    {
       
    }
}