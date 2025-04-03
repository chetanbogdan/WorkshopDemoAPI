using Ardalis.Result;
using MediatR;
using WorkshopDemoAPI.DAL;
using WorkshopDemoAPI.DAL.Entities;

namespace WorkshopDemoAPI.Application.Countries.CreateCountry;

public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, Result<CountryDto>>
{
    private readonly WorkshopDemoDbContext _context;

    public CreateCountryCommandHandler(WorkshopDemoDbContext context)
    {
        _context = context;
    }

    public async Task<Result<CountryDto>> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
    {
        var country = new Country
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            IsoCountryCode = request.IsoCountryCode
        };

        try
        {
            await _context.Countries.AddAsync(country, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Result<CountryDto>.Success(new CountryDto
            {
                Id = country.Id,
                Name = country.Name,
                IsoCountryCode = country.IsoCountryCode
            });
        }
        catch (Exception ex)
        {
            return Result<CountryDto>.CriticalError("An error occurred while processing your request");
        }

    }
}