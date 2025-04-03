using MediatR;

namespace WorkshopDemoAPI.Application.Countries.Queries.ListCountries;

public record ListCountriesQuery : IRequest<List<CountryDto>>;