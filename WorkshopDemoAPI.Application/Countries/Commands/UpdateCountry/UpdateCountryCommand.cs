using MediatR;

namespace WorkshopDemoAPI.Application.Countries.Commands.UpdateCountry;

public record UpdateCountryCommand(Guid Id, string Name, string IsoCountryCode) : IRequest;