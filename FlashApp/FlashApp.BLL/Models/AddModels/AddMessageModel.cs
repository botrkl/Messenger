namespace FlashApp.BLL.Models.AddModels
{
    public class AddMessageModel
    {
        public DateTime Creation_Time { get; set; } = DateTime.UtcNow;
        public string Content { get; set; }
        public string User_id { get; set; }
        public string Chat_id { get; set; }
    }
}
