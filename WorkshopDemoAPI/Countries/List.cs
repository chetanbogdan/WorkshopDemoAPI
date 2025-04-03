using Ardalis.Result.AspNetCore;
using FastEndpoints;
using MediatR;
using WorkshopDemoAPI.Application.Countries.ListCountries;

namespace WorkshopDemoAPI.Countries;

public class List : EndpointWithoutRequest<ListCountriesResponse>
{
    private readonly IMediator _mediator;

    public List(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override void Configure()
    {
        Get("api/countries");
        AllowAnonymous();
        Summary(s =>
        {
            s.Summary = "Lists all countries";
            s.Description = "Lists all countries";
        });
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var command = new ListCountriesQuery();
        
        var result = await _mediator.Send(command, ct);

        if (result.IsSuccess)
        {
            Response = new ListCountriesResponse
            {
                Countries = result.Value
            };
        }
        else
        {
            await SendResultAsync(result.ToMinimalApiResult());
        }
    }
}