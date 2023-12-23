using src.Dtos;

namespace src.Services.Interfaces;

public interface IWorkspaceService
{
    Task<IEnumerable<GetWorkspaceDto>> GetAllWorkspacesAsync();
    Task<GetWorkspaceDto?> GetWorkspaceByIdAsync(int id);
    Task<GetWorkspaceDto> CreateWorkspaceAsync(CreateWorkspaceDto workspaceDto);
    Task<GetWorkspaceDto> UpdateWorkspaceAsync(CreateWorkspaceDto workspaceDto);
    Task<bool> DeleteWorkspaceAsync(int id); 
}
