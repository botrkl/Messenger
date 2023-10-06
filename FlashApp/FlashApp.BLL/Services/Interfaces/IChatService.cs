﻿using FlashApp.BLL.Models;
using FlashApp.BLL.Models.AddModels;
using FlashApp.BLL.Models.UpdateModels;

namespace FlashApp.BLL.Services.Interfaces
{
    public interface IChatService
    {
        public Task<ChatModel> GetByIdAsync(Guid id);
        public Task DeleteChatAsync(Guid id);
        public Task<Guid> AddChatAsync(AddChatModel model);
        public Task UpdateChatAsync(UpdateChatModel model);
        public Task<IEnumerable<ChatModel>?> GetChatsByUserIdAsync(Guid userId);

    }
}
