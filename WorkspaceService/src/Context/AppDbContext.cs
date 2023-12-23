using Microsoft.EntityFrameworkCore;
using src.Context.Entities;

namespace src.Context;

public class AppDbContext : DbContext
{
    public DbSet<Workspace> Workspaces { get; set; } = null!;
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { } 
    
    protected override void OnModelCreating(ModelBuilder modelBuilder) { } 
}
