using FlashApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlashApp.DAL.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Username)
                .HasMaxLength(25)
                .IsRequired();

            builder
                .HasIndex(x => x.Username)
                .IsUnique();

            builder
                .Property(x => x.Password)
                .HasMaxLength(30)
                .IsRequired();

            builder
                .HasMany(user => user.ChatUsers)
                .WithOne(chatUser => chatUser.User)
                .HasForeignKey(chatUser => chatUser.UserId);

            builder
                .HasMany(x => x.Messages)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.User_id);
        }
    }
}
