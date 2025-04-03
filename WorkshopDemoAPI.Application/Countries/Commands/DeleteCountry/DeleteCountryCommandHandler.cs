using MediatR;
using WorkshopDemoAPI.Application.Common;

namespace WorkshopDemoAPI.Application.Countries.Commands.DeleteCountry;

public class DeleteCountryCommandHandler(IWorkshopDemoDbContext context) : IRequestHandler<DeleteCountryCommand>
{
    private readonly IWorkshopDemoDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

    public async Task Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Countries
            .FindAsync([request.CountryId], cancellationToken);
        
        
        _context.Countries.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }
}