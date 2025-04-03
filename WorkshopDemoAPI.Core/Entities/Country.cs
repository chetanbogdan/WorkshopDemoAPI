using WorkshopDemoAPI.Domain.Common;

namespace WorkshopDemoAPI.Domain.Entities;

public class Country : AuditableEntity
{
    public string Name { get; set; } = null!;
    public string IsoCountryCode { get; set; } = null!;
}