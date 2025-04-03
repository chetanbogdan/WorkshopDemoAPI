using Ardalis.Result;
using MediatR;

namespace WorkshopDemoAPI.Application.Countries.CreateCountry;

public record CreateCountryCommand(string Name, string IsoCountryCode) : IRequest<Result<CountryDto>>;