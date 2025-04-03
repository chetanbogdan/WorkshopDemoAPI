using Ardalis.Result;
using MediatR;
using WorkshopDemoAPI.DAL;

namespace WorkshopDemoAPI.Application.Countries.GetCountryById;

public class GetCountryByIdQueryHandler : IRequestHandler<GetCountryByIdQuery, Result<CountryDto>>
{
    private readonly WorkshopDemoDbContext _context;

    public GetCountryByIdQueryHandler(WorkshopDemoDbContext context)
    {
        _context = context;
    }

    public async Task<Result<CountryDto>> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var country = await _context.Countries.FindAsync([request.Id], cancellationToken);

            if (country is null)
            {
                return Result.NotFound($"Country with Id {request.Id} was not found");
            }

            return Result.Success(new CountryDto
            {
                Id = country.Id,
                Name = country.Name,
                IsoCountryCode = country.IsoCountryCode,
            });
        }
        catch (Exception ex)
        {
            return Result<CountryDto>.CriticalError("An error occurred while processing your request");
        }
    }
}