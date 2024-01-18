using Microsoft.EntityFrameworkCore;
using WorkspaceService.Infrastructure.Contexts.Entities;

namespace WorkspaceService.Infrastructure.Contexts;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Workspace> Workspaces { get; set; } = null!;
        
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    } 
}
