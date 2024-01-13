using FormService.Domain.Dtos.WorkspaceDtos;

namespace FormService.Domain.Interfaces;

public interface IWorkspaceService
{
    Task<IEnumerable<GetWorkspaceDto>> GetAllWorkspacesAsync(int id);
    Task<bool> WorkspacesExist(int id);
    Task<GetWorkspaceDto> CreateWorkspaceAsync(PublishedWorkspaceDto workspaceDto);
    Task<bool> UpdateWorkspaceAsync(PublishedWorkspaceDto workspaceDto);
    Task<bool> DeleteWorkspaceAsync(int id);  
}
