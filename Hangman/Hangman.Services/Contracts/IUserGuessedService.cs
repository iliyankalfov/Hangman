using Hangman.Data.Models;
using Hangman.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman.Services.UserServices
{
    public interface IUserGuessedService
    {
        void CreateUserGuessed(int userId, int wordId);

        void DeleteAllUserGuessed();

        //List<UserGuessed> GetAllGuessedWordsWithGivenUserId(int userId);
        //List<UserGuessed> GetAllWordsWithGivenUserIdDifficultyAndCategory(int userId, WordDifficulty wordDifficulty, int categoryId);
    }
}
