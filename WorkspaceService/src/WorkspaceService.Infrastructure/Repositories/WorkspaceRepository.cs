using WorkspaceService.Infrastructure.Contexts;
using WorkspaceService.Infrastructure.Contexts.Entities;
using WorkspaceService.Infrastructure.Interfaces;

namespace WorkspaceService.Infrastructure.Repositories;

public class WorkspaceRepository : Repository<Workspace>, IWorkspaceRepository
{
    public WorkspaceRepository(AppDbContext context) : base(context)
    {
    }
}
