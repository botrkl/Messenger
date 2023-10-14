namespace FlashApp.DAL.Context
{
    public class Initializer
    {
        public static void Initialize(MessengerDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
