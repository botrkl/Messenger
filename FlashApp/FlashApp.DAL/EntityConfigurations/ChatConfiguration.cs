using FlashApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlashApp.DAL.EntityConfigurations
{
    public class ChatConfiguration : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> builder)
        {
            builder
                .HasMany(chat => chat.ChatUsers)
                .WithOne(chatUser => chatUser.Chat)
                .HasForeignKey(chatUser => chatUser.ChatId);

            builder
                .HasMany(x => x.Messages)
                .WithOne(x => x.Chat)
                .HasForeignKey(x => x.Chat_id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
