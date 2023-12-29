using FormService.Infrastructure.Context.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FormService.Infrastructure.Context.Configs;

public class FormsConfig : IEntityTypeConfiguration<Form>
{
    public void Configure(EntityTypeBuilder<Form> builder)
    {
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(x => x.Description)
            .HasMaxLength(120);

        builder.Property(x => x.IsSubmissionOpen)
            .HasDefaultValue(1);

        builder.Property(x => x.FormSubmissionLimit)
            .HasDefaultValue(10000);

        builder.Property(x => x.StartDateTime)
            .HasDefaultValue(DateTime.UtcNow);

        builder.Property(x => x.CreatedAt)
            .HasDefaultValue(DateTime.UtcNow);

        builder.Property(x => x.WorkspaceId)
            .IsRequired();

        builder.HasMany(x => x.FormQuestions)
            .WithOne(x => x.Form)
            .HasForeignKey(x => x.FormId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
