namespace FlashApp.BLL.Exceptions
{
    public class AuthException : Exception
    {
        public AuthException()
            : base("Wrong login or password, authentication failed")
        {
        }
    }
}
