using FormFlowApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FormFlowApi.Data.DbContexts.Configs;

public class UserWorkspaceConfig : IEntityTypeConfiguration<UserWorkspace>
{
    public void Configure(EntityTypeBuilder<UserWorkspace> builder)
    {
        builder.HasKey(x => new { UserId = x.ApplicationUserId, x.WorkspaceId });
        
        builder.HasOne(x => x.Workspace)
            .WithMany(x => x.UserWorkspaces)
            .HasForeignKey(x => x.WorkspaceId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.ApplicationUser)
            .WithMany(x => x.Workspaces)
            .HasForeignKey(x => x.ApplicationUserId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
