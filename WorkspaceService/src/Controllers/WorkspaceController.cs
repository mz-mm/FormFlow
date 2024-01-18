using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using src.AsyncDataServices;
using src.Dtos;
using src.Services.Interfaces;

namespace src.Controllers;

[ApiController]
[Route("api/workspace")]
public class WorkspaceController(IMessageBusClient messageBusClient, IWorkspaceService service, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetWorkspaceDto>>> GetAllWorkspaces()
    {
        var result = await service.GetAllWorkspacesAsync();
        if (result.Any()) return Ok(result);

        return NotFound("No workspaces found");
    }

    [HttpGet("{id:int}", Name = "GetWorkspacesById")]
    public async Task<ActionResult<GetWorkspaceDto>> GetWorkspacesById(int id)
    {
        var result = await service.GetWorkspaceByIdAsync(id);
        if (result is not null) return Ok(result);

        return NotFound("No workspaces found");
    }

    [HttpPost]
    public async Task<ActionResult<GetWorkspaceDto>> CreateWorkspace([FromBody] CreateWorkspaceDto workspaceDto)
    {
        if (!ModelState.IsValid)
            return BadRequest("Invalid workspace attributes");

        try
        {
            var workspace = await service.CreateWorkspaceAsync(workspaceDto);
            var getWorkspaceDto = mapper.Map<GetWorkspaceDto>(workspace);
            
            var publishWorkspaceDto = mapper.Map<PublishWorkspaceDto>(getWorkspaceDto);
            publishWorkspaceDto.Event = "Workspace_Published";
            messageBusClient.PublishNewWorkspace(publishWorkspaceDto);

            return CreatedAtRoute(nameof(GetWorkspacesById), new { Id = workspace.Id }, getWorkspaceDto);
        }
        catch (ArgumentNullException exception)
        {
            return BadRequest($"Error creating workspace, workspace can't be null, detail: {exception.Message}");
        }
        catch (Exception exception)
        {
            return BadRequest($"Error creating workspace, detail: {exception.Message}");
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<GetWorkspaceDto>> CreateWorkspace(int id)
    {
        var result = await service.DeleteWorkspaceAsync(id);
        if (result) return Ok($"Workspace with Id: {id} successfully deleted");

        return BadRequest($"Error deleting workspace with Id: {id}");
    }
}
