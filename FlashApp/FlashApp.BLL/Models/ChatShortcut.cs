namespace FlashApp.BLL.Models
{
    public class ChatShortcut
    {
        public Guid chatId { get; set; }
        public string username { get; set; }
        public string? timeOfLastMessage { get; set; }
        public string? lastMessage { get; set; }
    }
}
