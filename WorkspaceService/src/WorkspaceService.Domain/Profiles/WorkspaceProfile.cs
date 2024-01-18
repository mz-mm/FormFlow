using AutoMapper;
using WorkspaceService.Domain.Dtos;
using WorkspaceService.Infrastructure.Contexts.Entities;

namespace WorkspaceService.Domain.Profiles;

public class WorkspaceProfile : Profile
{
    public WorkspaceProfile()
    {
        CreateMap<Workspace, GetWorkspaceDto>();
        CreateMap<CreateWorkspaceDto, Workspace>();
        CreateMap<GetWorkspaceDto, PublishWorkspaceDto>();
    }
}
