using AutoMapper;
using FormService.Domain.Dtos.WorkspaceDtos;
using FormService.Infrastructure.Context.Entities;

namespace FormService.Domain.Profiles;

public class WorkspaceProfile : Profile
{
    public WorkspaceProfile()
    {
        CreateMap<Workspace, GetWorkspaceDto>();
        CreateMap<PublishedWorkspaceDto, Workspace>();
    } 
}
