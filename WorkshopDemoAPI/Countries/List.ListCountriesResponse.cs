using WorkshopDemoAPI.Application.Countries;

namespace WorkshopDemoAPI.Countries;

public class ListCountriesResponse
{
    public List<CountryDto> Countries { get; set; } = new();
}