using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RouteProviders.Presentation.Controllers.MediatR;

[ApiController]
[Route("[controller]/api/v1")]
public abstract class BaseController : ControllerBase
{
    private IMediator _mediator = null!;

    protected IMediator Mediator
    {
        get
        {
            IMediator? service = HttpContext.RequestServices.GetService<IMediator>();

            if (_mediator is null)
            {
                if (service is null)
                    throw new Exception();

                _mediator = service;
            }

            return _mediator;
        }
    }
}