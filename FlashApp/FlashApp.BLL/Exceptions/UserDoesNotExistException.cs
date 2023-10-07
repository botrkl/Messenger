using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
