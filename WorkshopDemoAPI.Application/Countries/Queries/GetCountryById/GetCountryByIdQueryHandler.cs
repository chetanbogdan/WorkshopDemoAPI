using MediatR;
using Microsoft.EntityFrameworkCore;
using WorkshopDemoAPI.Application.Common;

namespace WorkshopDemoAPI.Application.Countries.Queries.GetCountryById;

public class GetCountryByIdQueryHandler(IWorkshopDemoDbContext context) : IRequestHandler<GetCountryByIdQuery, CountryDto>
{
    private readonly IWorkshopDemoDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
    
    public async Task<CountryDto> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
    {
        var country =  await _context.Countries
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);

        if (country is null)
        {
            throw new Exception("ex");
        }
        
        return new CountryDto
        {
            Id = country.Id,
            Name = country.Name,
            IsoCountryCode = country.IsoCountryCode
        };
    }
}