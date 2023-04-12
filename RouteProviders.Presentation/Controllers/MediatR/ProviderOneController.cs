using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using RouteProviders.Application.Contracts.Search.Queries;

namespace RouteProviders.Presentation.Controllers.MediatR;

public class ProviderOneController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IDistributedCache _cache;

    public ProviderOneController(IMediator mediator, IDistributedCache cache)
    {
        _mediator = mediator;
        _cache = cache;
    }

    [HttpGet("ping")]
    public Task<ActionResult> IsAvailable()
    {
        return Task.FromResult<ActionResult>(Ok());
    }

    [HttpPost("search")]
    public async Task<ActionResult<ProviderOneSearch.Response>> FindRoutes(ProviderOneSearch.Query query, [FromQuery] bool OnlyCached)
    {
        if (OnlyCached)
        {
            var cachedData = await _cache.GetStringAsync(query.ToString());

            var result = await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject(cachedData ?? string.Empty));

            return StatusCode(StatusCodes.Status200OK, result);
        }

        var response = await _mediator.Send(query);

        var serializedResponse = await Task.Factory.StartNew(() =>
            JsonConvert.SerializeObject(response));

        await _cache.SetStringAsync(query.ToString(), serializedResponse);

        return StatusCode(StatusCodes.Status200OK, response);
    }
}