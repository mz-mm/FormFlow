using FormService.Domain.Dtos.FormQuestionDtos;
using FormService.Domain.Exceptions;
using FormService.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FormService.Api.Controllers;

[ApiController]
[Route("api/form/{formId:int}/form-question")]
public class FormQuestionController(IFormQuestionService service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetFormQuestionDto>>> GetAllFormQuestions(int formId)
    {
        var result = await service.GetAllFormQuestionsAsync(formId);
        if (result.Any()) return Ok(result);

        return NotFound("Form questions not found");
    }

    [HttpPost]
    public async Task<ActionResult<GetFormQuestionDto>> CreateFormQuestion(int formId, [FromBody] CreateFormQuestionDto formQuestionDto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest("Model not valid");

            await service.CreateFormQuestionAsync(formId, formQuestionDto);

            return Ok("Form question created with success");
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult> UpdateFormQuestion(int formId, [FromBody] CreateFormQuestionDto formQuestionDto)
    {
        if (!ModelState.IsValid)
            return BadRequest("Model not valid");

        var result = await service.UpdateFormQuestionAsync(formId, formQuestionDto);

        if (result) return Ok("Form questions update with success");

        return BadRequest("Error update form question");
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteFormQuestion(int id)
    {
        var result = await service.DeleteFormQuestionAsync(id);

        if (result) return Ok($"Form question with ID: {id} deleted with success");

        return BadRequest($"Form question with ID: {id} could not be removed");
    }
}
