using FormService.Domain.Dtos.FormQuestionDtos;
using FormService.Domain.Exceptions;
using FormService.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FormService.Api.Controllers;

[ApiController]
[Route("api/form-question")]
public class FormQuestionController(IFormQuestionService service) : ControllerBase
{
    [HttpGet("{formId:int}")]
    public async Task<ActionResult<IEnumerable<GetFormQuestionDto>>> GetAllFormQuestions(int formId)
    {
        var result = await service.GetAllFormQuestionsAsync(formId);
        if (result.Any()) return Ok(result);

        return NotFound("Form questions not found");
    }

    [HttpPost]
    public async Task<ActionResult<GetFormQuestionDto>> CreateFormQuestion(
        [FromBody] CreateFormQuestionDto formQuestionDto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest("Model not valid");

            var result = await service.CreateFormQuestionAsync(formQuestionDto);

            if (result) return Ok("Form question created with success");

            return BadRequest("Error creating form question");
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult> UpdateFormQuestion([FromBody] CreateFormQuestionDto formQuestionDto)
    {
        if (!ModelState.IsValid)
            return BadRequest("Model not valid");

        var result = await service.UpdateFormQuestionAsync(formQuestionDto);

        if (result) return Ok("Form questions update with success");

        return BadRequest("Error update form question");
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteFormQuestion(int id)
    {
        var result = await service.DeleteFormQuestionAsync(id);

        if (result) return Ok($"Form question with {id} deleted with success");

        return BadRequest($"Form question with {id} not remove");
    }
}
