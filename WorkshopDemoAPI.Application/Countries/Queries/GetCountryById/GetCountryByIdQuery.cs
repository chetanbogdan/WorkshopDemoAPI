using MediatR;

namespace WorkshopDemoAPI.Application.Countries.Queries.GetCountryById;

public record GetCountryByIdQuery(Guid Id) : IRequest<CountryDto>;