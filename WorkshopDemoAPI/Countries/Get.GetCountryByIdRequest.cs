using Microsoft.AspNetCore.Mvc;

namespace WorkshopDemoAPI.Countries;

public class GetCountryByIdRequest
{
    public const string Route = "/api/countries/{countryId}";

    public Guid CountryId { get; set; }
}