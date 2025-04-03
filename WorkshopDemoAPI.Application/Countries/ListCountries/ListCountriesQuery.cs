using MediatR;

namespace WorkshopDemoAPI.Application.Countries.ListCountries;

public record ListCountriesQuery : IRequest<List<CountryDto>>;