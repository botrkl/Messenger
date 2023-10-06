using FlashApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlashApp.DAL.EntityConfigurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Creation_Time)
                .IsRequired();

            builder
                .Property(x => x.Content)
                .HasMaxLength(5000)
                .IsRequired();

            builder
                .Property(x => x.User_id)
                .IsRequired();

            builder
                .Property(x => x.Chat_id)
                .IsRequired();
        }
    }
}
