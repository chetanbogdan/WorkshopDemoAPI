using FastEndpoints;
using MediatR;
using WorkshopDemoAPI.Application.Countries.CreateCountry;

namespace WorkshopDemoAPI.Countries;

public class Create : Endpoint<CreateCountryRequest, CreateCountryResponse>
{
    private readonly IMediator _mediator;

    public Create(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override void Configure()
    {
        Post("api/countries");
        AllowAnonymous();
        Summary(s =>
        {
            s.Summary = "Create a new country";
            s.Description = "Create a new country";
            s.ExampleRequest = new CreateCountryRequest() { Name = "Romania", IsoCountryCode = "RO" };
        });
    }

    public override async Task HandleAsync(CreateCountryRequest req, CancellationToken ct)
    {
        var command = new CreateCountryCommand(req.Name!, req.IsoCountryCode!);
        
        var result = await _mediator.Send(command, ct);

        Response = new CreateCountryResponse
        {
            Country = result
        };
    }
}