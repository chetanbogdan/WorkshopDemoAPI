using Ardalis.Result;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WorkshopDemoAPI.DAL;

namespace WorkshopDemoAPI.Application.Countries.ListCountries;

public class ListCountriesQueryHandler : IRequestHandler<ListCountriesQuery, Result<List<CountryDto>>>
{
    private readonly WorkshopDemoDbContext _context;

    public ListCountriesQueryHandler(WorkshopDemoDbContext context)
    {
        _context = context;
    }

    public async Task<Result<List<CountryDto>>> Handle(ListCountriesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var countries = await _context.Countries.ToListAsync(cancellationToken);
            var countriesDto = countries.Select(x => new CountryDto
            {
                Id = x.Id,
                Name = x.Name,
                IsoCountryCode = x.IsoCountryCode
            }).ToList();

            return countriesDto;
        }
        catch (Exception ex)
        {
            return Result<List<CountryDto>>.CriticalError("An error occurred while processing your request");
        }
    }
}