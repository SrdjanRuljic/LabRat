using Application.AnalysisTypes.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace QualityManager.Controllers
{
    public class AnalysisTypesController(ISender sender) : BaseController(sender)
    {
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            var list = await Sender.Send(new GetAllQuery());

            return Ok(list);
        }
    }
}