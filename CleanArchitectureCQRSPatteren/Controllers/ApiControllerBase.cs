using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("uNIT_cqRS")]

namespace CleanArchitectureCQRSPatteren.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ApiControllerBase : ControllerBase
    {
        private ISender _mediator;
        protected ISender Mediator=>_mediator??=HttpContext.RequestServices.GetRequiredService<ISender>();

        // Added  this for testing
        internal void SetMediator(ISender mediator) => _mediator = mediator;
    }
}
