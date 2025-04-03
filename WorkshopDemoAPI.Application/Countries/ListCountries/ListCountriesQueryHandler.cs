using MediatR;
using Microsoft.EntityFrameworkCore;
using WorkshopDemoAPI.DAL;

namespace WorkshopDemoAPI.Application.Countries.ListCountries;

public class ListCountriesQueryHandler : IRequestHandler<ListCountriesQuery, List<CountryDto>>
{
    private readonly WorkshopDemoDbContext _context;

    public ListCountriesQueryHandler(WorkshopDemoDbContext context)
    {
        _context = context;
    }

    public async Task<List<CountryDto>> Handle(ListCountriesQuery request, CancellationToken cancellationToken)
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
}