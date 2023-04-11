using Microsoft.AspNetCore.Mvc;
using RouteProviders.Application.Contracts.Persistence;
using RouteProviders.Application.Contracts.Search.Queries;
using RouteProviders.Application.Implementations.Services;

namespace RouteProviders.Presentation.Controllers.Service;

[ResponseCache(Duration = 60,
    Location = ResponseCacheLocation.Any,
    VaryByQueryKeys = new string[] { "latest" })]
public class ProviderOneController : BaseController
{
    public ProviderOneController(IRouteProvidersDatabaseContext context)
    {
        _service = new ProviderOneService(context);
    }

    [HttpGet("ping")]
    public async Task<IActionResult> IsAvailable(CancellationToken cancellationToken)
    {
        var response = await _service.IsAvailableAsync(cancellationToken);

        return response ? StatusCode(StatusCodes.Status200OK) : StatusCode(StatusCodes.Status500InternalServerError);
    }

    [HttpPost("search")]
    public async Task<ActionResult<Search.Response>> FindRoutes(
        Search.Query query,
        CancellationToken cancellationToken)
    {
        return StatusCode(StatusCodes.Status200OK, await _service.SearchAsync(query, cancellationToken));
    }
}