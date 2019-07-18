using Hangman.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman.Services.UserServices
{
    public interface IUserGuessedService
    {
        void CreateUserGuessed(int userId, int wordId);

        void DeleteAllUserGuessed();

        List<UserGuessed> GetAllGuessedWordsWithGivenUserId(int userId);
    }
}
