using Evento.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Evento.EntityFrameworkCore.Events
{
    public class EventConfiguration:IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable(EventoConsts.DbTablePrefix + "Events" + EventoConsts.DbSchema);
            builder.ConfigureByConvention();
            
            builder.Property(x => x.Title).IsRequired().HasMaxLength(EventConsts.TitleMaxLength);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(EventConsts.DescriptionMaxLength);
            builder.HasMany<EventAttendee>().WithOne().HasForeignKey(x => x.EventId);
        }
    }
}