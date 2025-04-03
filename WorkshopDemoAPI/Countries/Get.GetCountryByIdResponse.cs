using WorkshopDemoAPI.Application.Countries;

namespace WorkshopDemoAPI.Countries;

public class GetCountryByIdResponse
{
    public CountryDto Country { get; set; } = null!;
}