using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace QualityManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController(ISender? sender) : ControllerBase
    {
        private ISender? _sender = sender;

        protected ISender? Sender => _sender ??= HttpContext.RequestServices.GetService<ISender>();
    }
}