using Microsoft.EntityFrameworkCore;
using src.Context;
using src.Context.Entities;
using src.Repositories.Interfaces;

namespace src.Repositories.Classes;

public class WorkspaceRepository : Repository<Workspace>, IWorkspaceRepository
{
    public WorkspaceRepository(AppDbContext context) : base(context)
    {
    }

}
