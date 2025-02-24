using Application.Products.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace QualityManager.Controllers
{
    public class ProductsController(ISender sender) : BaseController(sender)
    {
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Insert(InsertProductCommand command)
        {
            Guid id = await Sender.Send(command);

            return Ok(id);
        }
    }
}