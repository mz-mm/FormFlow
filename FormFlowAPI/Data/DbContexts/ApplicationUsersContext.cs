using FormFlowApi.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FormFlowApi.Data.DbContexts;

public class ApplicationUsersContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationUsersContext(DbContextOptions<ApplicationUsersContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<UserWorkspace>()
            .HasKey(uw => new { uw.ApplicationUserId, uw.WorkspaceId });

        modelBuilder.Entity<ApplicationUser>()
            .HasMany(x => x.Workspaces)
            .WithOne(x => x.ApplicationUser)
            .HasForeignKey(x => x.ApplicationUserId)
            .OnDelete(DeleteBehavior.NoAction);
    }
};
