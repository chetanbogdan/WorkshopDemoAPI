namespace WorkshopDemoAPI.Entities;

public class Country
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string IsoCountryCode { get; set; } = null!;
}