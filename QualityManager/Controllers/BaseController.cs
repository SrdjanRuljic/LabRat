using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace QualityManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController(ISender sender) : ControllerBase
    {
        protected ISender Sender { get; } = sender ?? throw new ArgumentNullException(nameof(sender));
    }
}