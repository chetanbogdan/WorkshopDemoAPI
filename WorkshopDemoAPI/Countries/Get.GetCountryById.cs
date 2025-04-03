using Ardalis.Result.AspNetCore;
using FastEndpoints;
using MediatR;
using WorkshopDemoAPI.Application.Countries.GetCountryById;

namespace WorkshopDemoAPI.Countries;

public class GetCountryById : Endpoint<GetCountryByIdRequest, GetCountryByIdResponse>
{
    private readonly IMediator _mediator;

    public GetCountryById(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override void Configure()
    {
        
        Get(GetCountryByIdRequest.Route);
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetCountryByIdRequest req, CancellationToken ct)
    {
        var result = await _mediator.Send(new GetCountryByIdQuery(req.CountryId), ct);

        if (result.IsSuccess)
        {
            Response = new GetCountryByIdResponse() { Country = result.Value };
        }
        else
        {
            await SendResultAsync(result.ToMinimalApiResult());
        }
    }

}