namespace FlashApp.DAL.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string? Nickname { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; }
        public virtual ICollection<ChatUser> ChatUsers { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
