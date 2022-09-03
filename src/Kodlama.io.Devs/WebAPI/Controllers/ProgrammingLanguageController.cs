using Application.Features.ProgrammingLanguages.Commands;
using Application.Features.ProgrammingLanguages.Dto;
using Application.Features.ProgrammingLanguages.Models;
using Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProgrammingLanguageController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateProgrammingLanguageCommand createProgrammingLanguageCommand)
    {
        CreateProgrammingLanguageDto result = await Mediator.Send(createProgrammingLanguageCommand);
        return Created("", result);
    }
    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListProgrammingLanguageQuery getListProgrammingLanguageQuery = new() { PageRequest = pageRequest };
        ProgrammingLanguageListModel result = await Mediator.Send(getListProgrammingLanguageQuery);
        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdProgrammingLanguageQuery getByIdProgrammingLanguageQuery)
    {
        ProgrammingLanguageGetByIdDto programmingLanguageGetByIdDto = await Mediator.Send(getByIdProgrammingLanguageQuery);
        return Ok(programmingLanguageGetByIdDto);
    }

    [HttpPut("{Id}")]
    public async Task<IActionResult> SoftDelete([FromRoute] DeleteProgrammingLanguageCommand deleteProgrammingLanguageCommand)
    {
        var result = await Mediator.Send(deleteProgrammingLanguageCommand);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateProgrammingLanguageCommand updateProgrammingLanguageCommand)
    {
        var result = await Mediator.Send(updateProgrammingLanguageCommand);
        return Ok(result);
    }

}
