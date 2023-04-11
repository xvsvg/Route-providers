using MediatR;
using Microsoft.AspNetCore.Mvc;
using RouteProviders.Application.Contracts.Search.Queries;

namespace RouteProviders.Presentation.Controllers.MediatR;

public class ProviderOneController : BaseController
{
    private readonly IMediator _mediator;

    public ProviderOneController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("ping")]
    public Task<ActionResult> IsAvailable()
    {
        return Task.FromResult<ActionResult>(Ok());
    }

    [HttpPost("search")]
    public async Task<ActionResult<ProviderOneSearch.Response>> FindRoutes(ProviderOneSearch.Query query)
    {
        var response = await _mediator.Send(query);
        return Ok(response);
    }
}