using MediatR;

namespace WorkshopDemoAPI.Application.Countries.Commands.CreateCountry;

public record CreateCountryCommand(string Name, string IsoCountryCode) : IRequest<Guid>;
