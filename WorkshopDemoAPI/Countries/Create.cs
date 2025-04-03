using FastEndpoints;
using MediatR;

namespace WorkshopDemoAPI.Countries;

public class Create(IMediator mediator) : Endpoint<CreateCountryRequest, CreateCountryResponse>
{
    public override void Configure()
    {
        Post("countries");
        Summary(s =>
        {
            s.Summary = "Create a new company withing a country";
            s.Description = "Create a new company withing a country";
            s.ExampleRequest = new CreateCountryRequest() { Name = "Romania", IsoCountryCode = "RO" };
        });
    }

    public override Task HandleAsync(CreateCountryRequest req, CancellationToken ct)
    {
        return base.HandleAsync(req, ct);
    }
}