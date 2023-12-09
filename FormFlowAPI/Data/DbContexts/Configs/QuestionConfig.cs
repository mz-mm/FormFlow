using FormFlowApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FormFlowApi.Data.DbContexts.Configs;

public class QuestionConfig : IEntityTypeConfiguration<FormQuestion>
{
    public void Configure(EntityTypeBuilder<FormQuestion> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.Question)
            .IsRequired()
            .HasMaxLength(FormQuestion.MaxQuestionLength);

        builder.Property(x => x.QuestionType)
            .IsRequired();
    }
}
