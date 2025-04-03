using System.Reflection;
using Microsoft.EntityFrameworkCore;
using WorkshopDemoAPI.Application.Common;
using WorkshopDemoAPI.Domain.Entities;

namespace WorkshopDemoAPI.Infrastructure.Data;

public class WorkshopDemoDbContext(DbContextOptions<WorkshopDemoDbContext> options) : DbContext(options), IWorkshopDemoDbContext
{
    public DbSet<Country> Countries => Set<Country>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}