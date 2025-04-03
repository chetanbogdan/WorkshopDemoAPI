using WorkshopDemoAPI.Application.Countries;

namespace WorkshopDemoAPI.Countries;

public class CreateCountryResponse
{
    public CountryDto Country { get; set; } = null!;
}