using FormService.Infrastructure.Context.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FormService.Infrastructure.Context.Configs;

public class FormsConfig : IEntityTypeConfiguration<Form>
{
    public void Configure(EntityTypeBuilder<Form> builder)
    {
        builder.Property(x => x.EventManagerId)
            .IsRequired();

        builder.Property(x => x.IsSubmissionOpen)
            .HasDefaultValue(true);
        
        builder.Property(x => x.FormName)
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(x => x.FormDescription)
            .HasMaxLength(120);

        builder.HasMany(x => x.FormQuestions)
            .WithOne(x => x.Form)
            .HasForeignKey(x => x.FormId)
            .OnDelete(DeleteBehavior.Cascade);;
    }
}
