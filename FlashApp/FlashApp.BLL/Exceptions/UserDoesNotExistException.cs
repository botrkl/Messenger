namespace FlashApp.BLL.Exceptions
{
    public class UserDoesNotExistException:Exception
    {
        public UserDoesNotExistException()
           : base("User with this username already exists!")
        {
        }
    }
}
