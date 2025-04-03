using MediatR;
using WorkshopDemoAPI.Application.Common;

namespace WorkshopDemoAPI.Application.Countries.Commands.UpdateCountry;

public class UpdateCountryCommandHandler(IWorkshopDemoDbContext context) : IRequestHandler<UpdateCountryCommand>
{
    private readonly IWorkshopDemoDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

    public async Task Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Countries
            .FindAsync([request.Id], cancellationToken);
        

        _context.Countries.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }
}