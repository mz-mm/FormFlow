using AutoMapper;
using src.Context.Entities;
using src.Dtos;
using src.Repositories.Interfaces;
using src.Services.Interfaces;

namespace src.Services.Classes;

public class WorkspaceService(IMapper mapper, IWorkspaceRepository workspaceRepository) : IWorkspaceService
{
    public async Task<IEnumerable<GetWorkspaceDto>> GetAllWorkspacesAsync()
    {
        var workspaces = await workspaceRepository.GetAllAsync();
        return mapper.Map<IEnumerable<GetWorkspaceDto>>(workspaces);
    }

    public async Task<GetWorkspaceDto?> GetWorkspaceByIdAsync(int id)
    {
        var workspace = await workspaceRepository.GetByIdAsync(id);
        return mapper.Map<GetWorkspaceDto>(workspace);
    }

    public async Task<GetWorkspaceDto> CreateWorkspaceAsync(CreateWorkspaceDto workspaceDto)
    {
        var workspaceEntity = mapper.Map<Workspace>(workspaceDto);
        var workspace = await workspaceRepository.InsertAsync(workspaceEntity);
        
        return mapper.Map<GetWorkspaceDto>(workspace);
    }
    
    public async Task<GetWorkspaceDto> UpdateWorkspaceAsync(CreateWorkspaceDto workspaceDto)
    {
        var workspaceEntity = mapper.Map<Workspace>(workspaceDto);
        var workspace = await workspaceRepository.UpdateAsync(workspaceEntity);

        return mapper.Map<GetWorkspaceDto>(workspace);
    }

    public async Task<bool> DeleteWorkspaceAsync(int id)
    {
        var workspace = await workspaceRepository.GetByIdAsync(id);
        
        if (workspace is null)
            return false;

        return await workspaceRepository.DeleteAsync(workspace);
    }
}
