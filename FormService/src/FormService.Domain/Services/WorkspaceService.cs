using AutoMapper;
using FormService.Domain.Dtos.WorkspaceDtos;
using FormService.Domain.Interfaces;
using FormService.Infrastructure.Context.Entities;
using FormService.Infrastructure.Interfaces;

namespace FormService.Domain.Services;

public class WorkspaceService(IMapper mapper, IWorkspaceRepository workspaceRepository) : IWorkspaceService
{
    public async Task<IEnumerable<GetWorkspaceDto>> GetAllWorkspacesAsync(int id)
    {
        var workspaces = (await workspaceRepository.GetAllAsync())
            .Where(workspace => workspace.Id == id);

        return mapper.Map<IEnumerable<GetWorkspaceDto>>(workspaces);
    }

    public async Task<bool> WorkspacesExist(int id)
    {
        var workspaces = await workspaceRepository.GetByIdAsync(id);
        return workspaces is not null;
    }

    public async Task<GetWorkspaceDto> CreateWorkspaceAsync(PublishedWorkspaceDto workspaceDto)
    {
        var workspaceEntity = mapper.Map<Workspace>(workspaceDto);
        var result = await workspaceRepository.InsertAsync(workspaceEntity);

        return mapper.Map<GetWorkspaceDto>(result);
    }

    public async Task<bool> UpdateWorkspaceAsync(PublishedWorkspaceDto workspaceDto)
    {
        var workspaceEntity = mapper.Map<Workspace>(workspaceDto);
        var result = await workspaceRepository.UpdateAsync(workspaceEntity);

        return result;
    }

    public async Task<bool> DeleteWorkspaceAsync(int workspaceId)
    {
        var workspace = await workspaceRepository.GetByIdAsync(workspaceId);

        if (workspace is null)
            return false;

        var result = await workspaceRepository.DeleteAsync(workspace);

        return result;
    }
}
