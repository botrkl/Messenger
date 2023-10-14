namespace FlashApp.BLL.Exceptions
{
    public class RegisterException:Exception
    {
        public RegisterException()
           : base("User with this username already exists!")
        {
        }
    }
}
