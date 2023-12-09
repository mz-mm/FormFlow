using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FormFlowApi.Data.DbContexts.Configs;

public class FormConfig : IEntityTypeConfiguration<Models.Form>
{
    public void Configure(EntityTypeBuilder<Models.Form> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.FormName)
            .IsRequired()
            .HasMaxLength(Models.Form.MaxFormNameLength);

        builder.Property(x => x.FormDescription)
            .HasMaxLength(Models.Form.MaxFormDescriptionLength);

        builder.HasMany(x => x.FormQuestions)
            .WithOne(x => x.Form)
            .HasForeignKey(x => x.FormId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
