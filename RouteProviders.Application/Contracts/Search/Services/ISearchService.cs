namespace RouteProviders.Application.Contracts.Search.Services;

public interface ISearchService
{
    Task<Queries.Search.Response> SearchAsync(Queries.Search.Query request, CancellationToken cancellationToken);
    Task<bool> IsAvailableAsync(CancellationToken cancellationToken);
}