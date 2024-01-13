using FormService.Domain.Dtos.FormDtos;
using FormService.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FormService.Api.Controllers;

[ApiController]
[Route("api/form/{workspaceId:int}/form")]
public class FormController(IFormService service) : ControllerBase
{
   [HttpGet]
   public async Task<ActionResult<IEnumerable<GetFormDto>>> GetAllForms(int workspaceId)
   {
      var result = await service.GetAllFormsAsync(workspaceId);
      if (result.Any()) return Ok(result);

      return NotFound("Forms not found");
   }
   
   [HttpGet("{formId:int}")]
   public async Task<ActionResult<GetFormDto>> GetForm(int formId)
   {
      var result = await service.GetFormByIdAsync(formId);
      
      if (result is not null) return Ok(result);

      return NotFound("Form not found");
   }
   
   [HttpPost]
   public async Task<ActionResult<GetFormDto>> CreateForm(int workspaceId, [FromBody] CreateFormDto formDto)
   {
      if (!ModelState.IsValid)
         return BadRequest("Model not valid");

      await service.CreateFormAsync(workspaceId, formDto);

      return Ok("Form created with success");
   } 
   
   [HttpPut]
   public async Task<ActionResult> UpdateForm(int workspaceId, [FromBody] CreateFormDto formDto)
   {
      if (!ModelState.IsValid)
         return BadRequest("Model not valid");

      var result = await service.UpdateFormAsync(workspaceId, formDto);
            
      if (result) return Ok("Form update with success");

      return BadRequest("Error update form");
   }
   
   [HttpDelete("{formId:int}")] 
   public async Task<ActionResult> DeleteForm(int formId)
   {
      var result = await service.DeleteFormAsync(formId);

      if (result) return Ok($"Form with ID: {formId} deleted with success");

      return BadRequest($"Form with ID: {formId} could not be removed");
   } 
}
