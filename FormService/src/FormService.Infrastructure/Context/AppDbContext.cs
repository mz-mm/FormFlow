using FormService.Infrastructure.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace FormService.Infrastructure.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Form> Forms { get; set; } = null!;
    public DbSet<FormQuestion> FormQuestions { get; set; } = null!;
    public DbSet<Workspace> Workspaces { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }

}
