using Microsoft.AspNetCore.Mvc;
using RouteProviders.Application.Contracts.Persistence;
using RouteProviders.Application.Contracts.Search.Services;
#pragma warning disable CS8618

namespace RouteProviders.Presentation.Controllers.Service;

[ApiController]
[Route("[controller]/api/v1")]
public abstract class BaseController : ControllerBase
{
    protected ISearchService _service;
}