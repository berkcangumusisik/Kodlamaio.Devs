using Application.Features.Socials.Command.CreateSocial;
using Application.Features.Socials.Command.DeleteSocial;
using Application.Features.Socials.Command.UpdateSocial;
using Application.Features.Socials.Queries;
using Core.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SocialController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListSocialsQuery socialsQuery = new() { PageRequest = pageRequest };
            var result = await _mediator.Send(socialsQuery);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateSocialCommand createSocialCommand)
        {
            var result = await _mediator.Send(createSocialCommand);
            return Ok(result);

        }


        [HttpPut]
        public async Task<IActionResult> Update(UpdateSocialCommand updateSocialCommand)
        {
            var result = await _mediator.Send(updateSocialCommand);

            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteSocialCommand deleteSocialCommand)
        {
            var result = await _mediator.Send(deleteSocialCommand);

            return Ok(result);
        }

    }
}
