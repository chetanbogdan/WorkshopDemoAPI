using Microsoft.EntityFrameworkCore;
using WorkshopDemoAPI.Domain.Entities;

namespace WorkshopDemoAPI.Application.Common;

public interface IWorkshopDemoDbContext
{
    DbSet<Country> Countries { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}