using AutoMapper;
using src.Context.Entities;
using src.Dtos;

namespace src.Profiles;

public class WorkspaceProfile : Profile
{
    public WorkspaceProfile()
    {
        CreateMap<Workspace, GetWorkspaceDto>();
        CreateMap<CreateWorkspaceDto, Workspace>();
    }
}
