using FormFlowApi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FormFlowApi.Data.DbContexts;

public class FormDbContext(DbContextOptions<FormDbContext> options) : DbContext(options)
{
    public DbSet<Workspace> Workspaces { get; set; } = null!;
    public DbSet<EventManager> EventManagers { get; set; } = null!;
    public DbSet<UserWorkspace> UserWorkspaces { get; set; } = null!;
    public DbSet<Models.Form> Forms { get; set;  } = null!;
    public DbSet<FormQuestion> FormQuestions { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FormDbContext).Assembly);
    }
}
