using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkshopDemoAPI.Entities;

namespace WorkshopDemoAPI.Data.Configurations;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.HasKey(country => country.Id);
        builder.Property(zone => zone.Id).ValueGeneratedNever();
        
        builder.Property(zone => zone.Name)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(zone => zone.IsoCountryCode)
            .IsRequired()
            .HasMaxLength(2);
    }
}