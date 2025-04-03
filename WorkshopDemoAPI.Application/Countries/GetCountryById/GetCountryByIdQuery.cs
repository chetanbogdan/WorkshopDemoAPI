using Ardalis.Result;
using MediatR;

namespace WorkshopDemoAPI.Application.Countries.GetCountryById;

public record GetCountryByIdQuery(Guid Id) : IRequest<Result<CountryDto>>;