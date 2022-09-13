using Application.Features.Technologies.Commands.CreateTechnology;
using Application.Features.Technologies.Commands.UpdateTechnology;
using Application.Features.Technology.Commands.DeleteTechnology;
using Application.Features.Technology.Queires.GetById;
using Application.Features.Technology.Queires.GetList;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologyController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetListTechnology([FromQuery] PageRequest pageRequest)
        {
            GetListTechnologyQuery technologyQuery = new() { PageRequest = pageRequest };
            var result = await Mediator.Send(technologyQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdTechnology([FromRoute] GetByIdTechnologyQuery getByIdTechnologyQuery)
        {
            var result = await Mediator.Send(getByIdTechnologyQuery);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddTechnology([FromBody] CreateTechnologyCommand createTechnologyCommand)
        {
            var result = await Mediator.Send(createTechnologyCommand);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTechnology([FromBody] UpdateTechnologyCommand updateTechnologyCommand)
        {
            var result = await Mediator.Send(updateTechnologyCommand);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTechnology([FromQuery] DeleteTechnologyCommand deleteTechnologyCommand)
        {
            var result = await Mediator.Send(deleteTechnologyCommand);
            return Ok(result);
        }

    }
}
