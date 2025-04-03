using MediatR;
using WorkshopDemoAPI.DAL;
using WorkshopDemoAPI.DAL.Entities;

namespace WorkshopDemoAPI.Application.Countries.CreateCountry;

public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, CountryDto>
{
    private readonly WorkshopDemoDbContext _context;

    public CreateCountryCommandHandler(WorkshopDemoDbContext context)
    {
        _context = context;
    }

    public async Task<CountryDto> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
    {
        var country = new Country
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            IsoCountryCode = request.IsoCountryCode
        };
        
        await _context.Countries.AddAsync(country, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        
        var countryDto = new CountryDto
        {
            Id = country.Id,
            Name = country.Name,
            IsoCountryCode = country.IsoCountryCode
        };

        return countryDto;
    }
}