using Ardalis.Result;
using MediatR;

namespace WorkshopDemoAPI.Application.Countries.ListCountries;

public record ListCountriesQuery : IRequest<Result<List<CountryDto>>>;