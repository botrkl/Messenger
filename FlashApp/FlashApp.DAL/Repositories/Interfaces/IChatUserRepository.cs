using FlashApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashApp.DAL.Repositories.Interfaces
{
    public interface IChatUserRepository
    {
        public Task AddAsync(ChatUser entity);
    }
}
