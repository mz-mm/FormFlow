using FormService.Domain.Dtos.FormDtos;
using FormService.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FormService.Api.Controllers;

[ApiController]
[Route("api/form")]
public class FormController(IFormService service) : ControllerBase
{
   [HttpGet]
   public async Task<ActionResult<IEnumerable<GetFormDto>>> GetAllForms()
   {
      var result = await service.GetAllFormsAsync();
      if (result.Any()) return Ok(result);

      return NotFound("Forms not found");
   }
   
   [HttpGet("{id:int}")]
   public async Task<ActionResult<GetFormDto>> GetForm(int id)
   {
      var result = await service.GetFormByIdAsync(id);
      
      if (result is not null) return Ok(result);

      return NotFound("Form not found");
   }
   
   [HttpPost]
   public async Task<ActionResult<GetFormDto>> CreateForm([FromBody] CreateFormDto formDto)
   {
      if (!ModelState.IsValid)
         return BadRequest("Model not valid");

      var result = await service.CreateFormAsync(formDto);

      if (result) return Ok("Form created with success");
            
      return BadRequest("Error creating form");
   } 
   
   [HttpPut]
   public async Task<ActionResult> UpdateForm([FromBody] CreateFormDto formDto)
   {
      if (!ModelState.IsValid)
         return BadRequest("Model not valid");

      var result = await service.UpdateFormAsync(formDto);
            
      if (result) return Ok("Form update with success");

      return BadRequest("Error update form");
   }
   
   [HttpDelete("{id:int}")] 
   public async Task<ActionResult> DeleteForm(int id)
   {
      var result = await service.DeleteFormAsync(id);

      if (result) return Ok($"Form with {id} deleted with success");

      return BadRequest($"Form with {id} not remove");
   } 
}
