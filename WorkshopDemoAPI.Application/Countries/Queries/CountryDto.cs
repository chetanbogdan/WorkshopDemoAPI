namespace WorkshopDemoAPI.Application.Countries.Queries;

public class CountryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string IsoCountryCode { get; set; } = null!;
}