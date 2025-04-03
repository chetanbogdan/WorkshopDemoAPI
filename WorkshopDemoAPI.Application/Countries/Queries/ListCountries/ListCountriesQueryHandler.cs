using MediatR;
using Microsoft.EntityFrameworkCore;
using WorkshopDemoAPI.Application.Common;

namespace WorkshopDemoAPI.Application.Countries.Queries.ListCountries;

public class ListCountriesQueryHandler(IWorkshopDemoDbContext context) : IRequestHandler<ListCountriesQuery, List<CountryDto>>
{
    private readonly IWorkshopDemoDbContext _context = context ?? throw new ArgumentNullException(nameof(context)); 
    
    public async Task<List<CountryDto>> Handle(ListCountriesQuery request, CancellationToken cancellationToken)
    {
        var countries = await _context.Countries.ToListAsync(cancellationToken);
        
        var countriesDtos = countries.Select(x => new CountryDto
        {
            Id = x.Id,
            Name = x.Name,
            IsoCountryCode = x.IsoCountryCode,
        }).ToList();
        
        return countriesDtos;
    }
}