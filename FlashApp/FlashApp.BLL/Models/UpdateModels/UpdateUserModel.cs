﻿namespace FlashApp.BLL.Models.UpdateModels
{
    public class UpdateUserModel
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string? Nickname { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; }
    }
}
