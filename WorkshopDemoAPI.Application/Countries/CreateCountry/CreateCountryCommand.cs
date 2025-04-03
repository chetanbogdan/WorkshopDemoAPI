using MediatR;

namespace WorkshopDemoAPI.Application.Countries.CreateCountry;

public record CreateCountryCommand(string Name, string IsoCountryCode) : IRequest<CountryDto>;