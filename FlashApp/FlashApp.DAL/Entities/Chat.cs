namespace FlashApp.DAL.Entities
{
    public class Chat : BaseEntity
    {
        public virtual ICollection<ChatUser> ChatUsers { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
