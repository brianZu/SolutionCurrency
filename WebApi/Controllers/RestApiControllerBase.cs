using MediatR;
using TMI.Library.Utils.ApiSecurity.Controllers;

namespace WebApi.Controllers
{
    public abstract class RestApiControllerBase : ApiControllerBase
    {
        private ISender _mediator = null!;

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}
