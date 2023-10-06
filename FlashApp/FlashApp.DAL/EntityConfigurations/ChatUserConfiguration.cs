using FlashApp.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FlashApp.DAL.EntityConfigurations
{
    public class ChatUserConfiguration : IEntityTypeConfiguration<ChatUser>
    {
        public void Configure(EntityTypeBuilder<ChatUser> builder)
        {
            builder
                .HasKey(chatUser => new { chatUser.ChatId, chatUser.UserId });

            builder
                .HasOne(chatUser => chatUser.Chat)
                .WithMany(chat => chat.ChatUsers)
                .HasForeignKey(chatUser => chatUser.ChatId);

            builder
                .HasOne(chatUser => chatUser.User)
                .WithMany(user => user.ChatUsers)
                .HasForeignKey(chatUser => chatUser.UserId);
        }
    }
}
