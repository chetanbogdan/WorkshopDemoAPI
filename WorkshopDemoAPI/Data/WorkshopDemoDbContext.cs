using System.Reflection;
using Microsoft.EntityFrameworkCore;
using WorkshopDemoAPI.Entities;

namespace WorkshopDemoAPI.Data;

public class WorkshopDemoDbContext(DbContextOptions<WorkshopDemoDbContext> options) : DbContext(options)
{
    public DbSet<Country> Countries => Set<Country>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}