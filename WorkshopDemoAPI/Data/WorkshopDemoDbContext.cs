using System.Reflection;
using Microsoft.EntityFrameworkCore;
using WorkshopDemoAPI.Entities;

namespace WorkshopDemoAPI.Data;

public class WorkshopDemoDbContext(DbContextOptions<WorkshopDemoDbContext> options) : DbContext(options)
{
    public DbSet<Country> Countries => Set<Country>();
    public DbSet<Client> Clients => Set<Client>();
    public DbSet<ApiKey> ApiKeys => Set<ApiKey>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}