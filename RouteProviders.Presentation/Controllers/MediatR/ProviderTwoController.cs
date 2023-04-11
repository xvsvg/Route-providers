using MediatR;
using Microsoft.AspNetCore.Mvc;
using RouteProviders.Application.Contracts.Search.Queries;

namespace RouteProviders.Presentation.Controllers.MediatR;

public class ProviderTwoController : BaseController
{
    private readonly IMediator _mediator;

    public ProviderTwoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("ping")]
    public Task<ActionResult> IsAvailable()
    {
        return Task.FromResult<ActionResult>(Ok());
    }

    [HttpPost("search")]
    public async Task<ActionResult<ProviderTwoSearch.Response>> FindRoutes(ProviderTwoSearch.Query query)
    {
        var response = await _mediator.Send(query);
        return Ok(response);
    }
}