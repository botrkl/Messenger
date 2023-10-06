namespace FlashApp.DAL.Entities
{
    public class Message : BaseEntity
    {
        public DateTime Creation_Time { get; set; } = DateTime.Now;
        public string Content { get; set; }
        public Guid User_id { get; set; }
        public Guid Chat_id { get; set; }
        public virtual Chat Chat { get; set; }        
        public virtual User User { get; set; }
    }
}
