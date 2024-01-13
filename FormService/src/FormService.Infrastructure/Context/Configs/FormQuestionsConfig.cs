using FormService.Infrastructure.Context.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FormService.Infrastructure.Context.Configs;

public class FormQuestionsConfig : IEntityTypeConfiguration<FormQuestion> 
{
    public void Configure(EntityTypeBuilder<FormQuestion> builder)
    {
        builder.Property(x => x.Question)
            .IsRequired()
            .HasMaxLength(120);

        builder.Property(x => x.QuestionType)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .HasDefaultValue(DateTime.UtcNow);

        builder.HasOne(x => x.Form)
            .WithMany(x => x.FormQuestions)
            .HasForeignKey(x => x.FormId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
