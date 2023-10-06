using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
