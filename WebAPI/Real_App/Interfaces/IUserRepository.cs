﻿using Real_App.Model;

namespace Real_App.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Authenticate(string userName, string password);

        void Register(string userName, string password);

        Task<bool> UserAlreadyExists(string userName);
    }
}
