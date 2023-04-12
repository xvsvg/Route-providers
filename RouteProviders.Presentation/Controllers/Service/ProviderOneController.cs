using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using RouteProviders.Application.Contracts.Persistence;
using RouteProviders.Application.Contracts.Search.Queries;
using RouteProviders.Application.Implementations.Services;
using RouteProviders.Presentation.Contracts.Search.Filters;

namespace RouteProviders.Presentation.Controllers.Service;

public class ProviderOneController : BaseController
{
    private readonly IDistributedCache _cache;

    public ProviderOneController(IRouteProvidersDatabaseContext context, IDistributedCache cache)
    {
        _service = new ProviderOneService(context);
        _cache = cache;
    }

    [HttpGet("ping")]
    public async Task<IActionResult> IsAvailable(CancellationToken cancellationToken)
    {
        var response = await _service.IsAvailableAsync(cancellationToken);

        return response ? StatusCode(StatusCodes.Status200OK) : StatusCode(StatusCodes.Status500InternalServerError);
    }

    [HttpPost("search")]
    public async Task<ActionResult<Search.Response>> FindRoutes(
        [FromBody] Search.Query query,
        CancellationToken cancellationToken)
    {
        if (query.Filter?.OnlyCached is true)
        {
            var response = await _cache.GetStringAsync(query.ToString(), cancellationToken);

            var result = await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<Search.Response>(response ?? string.Empty), cancellationToken);

            return StatusCode(StatusCodes.Status200OK, result);
        }

        try
        {
            var dbResponse = await _service.SearchAsync(query, cancellationToken);

            var serializedResponse = await Task.Factory.StartNew(() =>
                JsonConvert.SerializeObject(dbResponse), cancellationToken);

            var key = new Search.Query(
                query.Origin,
                query.Destination,
                query.OriginDateTime,
                new Filter(
                    query.Filter?.DestinationDateTime,
                    query.Filter?.MaxPrice,
                    query.Filter?.DestinationDateTime,
                    true
                ));

            await _cache.SetStringAsync(key.ToString(), serializedResponse, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(5)
            }, cancellationToken);


            return StatusCode(StatusCodes.Status200OK, dbResponse);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status404NotFound, ex.Message);
        }
    }
}