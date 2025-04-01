using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkshopDemoAPI.Entities;

namespace WorkshopDemoAPI.Data.Configurations;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();
        
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(x => x.CreditsRemaining)
            .HasDefaultValue(100);

        builder.HasMany<ApiKey>(x => x.ApiKeys)
            .WithOne(x => x.Client)
            .HasForeignKey(x => x.ClientId);
    }
}