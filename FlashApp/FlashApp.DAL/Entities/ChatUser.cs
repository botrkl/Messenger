namespace FlashApp.DAL.Entities
{
    public class ChatUser
    {
        public Guid ChatId { get; set; }
        public Guid UserId { get; set; }
        public virtual Chat Chat { get; set; }
        public virtual User User { get; set; }
    }
}
