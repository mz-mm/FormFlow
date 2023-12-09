using FormFlowApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FormFlowApi.Data.DbContexts.Configs;

public class WorkspaceConfig : IEntityTypeConfiguration<Workspace>
{
    public void Configure(EntityTypeBuilder<Workspace> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.WorkspaceName)
            .IsRequired()
            .HasMaxLength(Workspace.MAxWorkspaceName);

        builder.Property(x => x.WorkspaceDescription)
            .HasMaxLength(Workspace.MAxWorkspaceDescription);

        builder.HasMany(x => x.EventManagers)
            .WithOne(x => x.Workspace)
            .HasForeignKey(x => x.WorkspaceId)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.HasMany(x => x.UserWorkspaces)
            .WithOne(x => x.Workspace)
            .HasForeignKey(x => x.WorkspaceId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
