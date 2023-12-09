using FormFlowApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FormFlowApi.Data.DbContexts.Configs;

public class EventManagerConfig : IEntityTypeConfiguration<EventManager>
{
    public void Configure(EntityTypeBuilder<EventManager> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.EventName)
            .IsRequired()
            .HasMaxLength(EventManager.MaxEventNameLength);
        
        builder.Property(x => x.EventDescription)
            .IsRequired()
            .HasMaxLength(EventManager.MaxEventDescriptionLength);

        builder.HasMany(x => x.Forms)
            .WithOne(x => x.EventManager)
            .HasForeignKey(x => x.EventManagerId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
