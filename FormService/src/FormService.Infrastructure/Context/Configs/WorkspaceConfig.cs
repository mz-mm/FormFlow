using FormService.Infrastructure.Context.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FormService.Infrastructure.Context.Configs;

public class WorkspaceConfig : IEntityTypeConfiguration<Workspace>
{
    public void Configure(EntityTypeBuilder<Workspace> builder)
    {
        builder.HasMany(x => x.Forms)
            .WithOne(x => x.Workspace)
            .HasForeignKey(x => x.WorkspaceId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
