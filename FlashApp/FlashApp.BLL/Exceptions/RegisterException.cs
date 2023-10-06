using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
