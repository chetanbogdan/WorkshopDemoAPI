using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkshopDemoAPI.Entities;

namespace WorkshopDemoAPI.Data.Configurations;

public class ApiKeyConfiguration : IEntityTypeConfiguration<ApiKey>
{
    public void Configure(EntityTypeBuilder<ApiKey> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();
        
        builder.Property(x => x.Value)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.IsDisabled)
            .HasDefaultValue(false);
    }
}