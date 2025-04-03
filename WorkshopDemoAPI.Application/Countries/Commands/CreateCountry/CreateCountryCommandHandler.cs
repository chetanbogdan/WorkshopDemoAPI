using MediatR;
using WorkshopDemoAPI.Application.Common;
using WorkshopDemoAPI.Domain.Entities;

namespace WorkshopDemoAPI.Application.Countries.Commands.CreateCountry;

public class CreateCountryCommandHandler(IWorkshopDemoDbContext context) : IRequestHandler<CreateCountryCommand, Guid>
{
    private readonly IWorkshopDemoDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

    public async Task<Guid> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
    {
        var country = new Country
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            IsoCountryCode = request.IsoCountryCode
        };
        
        await _context.Countries.AddAsync(country);
        await _context.SaveChangesAsync(cancellationToken);
        
        return country.Id;
    }
}