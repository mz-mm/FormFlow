using FormService.Infrastructure.Context;
using FormService.Infrastructure.Context.Entities;
using FormService.Infrastructure.Interfaces;

namespace FormService.Infrastructure.Repositories;

public class WorkspaceRepository(AppDbContext context) : Repository<Workspace>(context), IWorkspaceRepository
{
}
