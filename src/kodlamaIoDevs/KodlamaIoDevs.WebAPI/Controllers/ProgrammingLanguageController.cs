using Core.Application.Requests;
using KodlamaIoDevs.Application.Features.ProgramminLanguages.Commands.CreateProgrammingLanguage;
using KodlamaIoDevs.Application.Features.ProgramminLanguages.Commands.DeleteProgrammingLanguageCommand;
using KodlamaIoDevs.Application.Features.ProgramminLanguages.Commands.UpdateProgrammingLanguageCommand;
using KodlamaIoDevs.Application.Features.ProgramminLanguages.Dtos;
using KodlamaIoDevs.Application.Features.ProgramminLanguages.Models;
using KodlamaIoDevs.Application.Features.ProgramminLanguages.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KodlamaIoDevs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguageController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProgramminLanguageCommand createProgramminLanguageCommand)
        {
            CreatedProgramminLangueageDto result = await Mediator.Send(createProgramminLanguageCommand);
            return Created("", result);
        }

        [HttpPut("/delete/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProgrammingLanguageCommand deleteProgrammingLanguageCommand)
        {
            DeletedProgrammingLanguageDto result = await Mediator.Send(deleteProgrammingLanguageCommand);
            return Ok(result);
        }

        [HttpPut("/update")]
        public async Task<IActionResult> Update([FromBody] UpdateProgrammingLanguageCommand updateProgrammingLanguageCommand)
        {
            UpdatedProgrammingLanguageDto result = await Mediator.Send(updateProgrammingLanguageCommand);
            return Ok(result);
        }

        [HttpGet("/getAll")]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            GetListProgrammingLanguageQuery getListProgrammingLanguageQuery = new() { PageRequest = pageRequest };
            ProgrammingLanguageListModel result = await Mediator.Send(getListProgrammingLanguageQuery);

            return Ok(result);
        }

        [HttpGet("/getById/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProgrammingLanguageQuery getByIdProgrammingLanguageQuery)
        {
            GetByIdProgrammingLanguageDto result = await Mediator.Send(getByIdProgrammingLanguageQuery);

            return Ok(result);
        }
    }
}
