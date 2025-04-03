using MediatR;

namespace WorkshopDemoAPI.Application.Countries.Commands.DeleteCountry;

public record DeleteCountryCommand(Guid CountryId) : IRequest;