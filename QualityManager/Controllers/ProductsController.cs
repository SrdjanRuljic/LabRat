using Application.Common.Interfaces;
using Application.Products.Commands;
using Domain.Enums;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace QualityManager.Controllers
{
    public class ProductsController(ISender? sender, IPublishEndpoint publishEndpoint) : BaseController(sender)
    {
        #region [POST]

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Insert(InsertProductCommand command)
        {
            Guid id = await Sender?.Send(command)!;

            return Ok(id);
        }

        #endregion [POST]
    }
}