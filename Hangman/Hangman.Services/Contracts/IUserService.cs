using Hangman.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman.Services.UserServices
{
    public interface IUserService
    {
        void CreateUser(string email, string password);

        List<User> GetAllUsers();

        void DeleteAllUsers();

        int GetUserIdWithGivenEmailAndPassword(string email,string password);
    }
}
