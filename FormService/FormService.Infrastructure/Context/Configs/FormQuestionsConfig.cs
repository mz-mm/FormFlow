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
    }
}
