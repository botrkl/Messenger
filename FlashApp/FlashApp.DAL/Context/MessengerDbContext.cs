using FlashApp.DAL.Entities;
using FlashApp.DAL.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
namespace FlashApp.DAL.Context
{
    public class MessengerDbContext:DbContext
    {
        public MessengerDbContext(DbContextOptions options) : base(options){}

        public DbSet<User> User { get; set; }
        public DbSet<ChatUser> ChatUser { get; set; }
        public DbSet<Chat> Chat { get; set; }
        public DbSet<Message> Message { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ChatUserConfiguration());
            modelBuilder.ApplyConfiguration(new ChatConfiguration());
            modelBuilder.ApplyConfiguration(new MessageConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
