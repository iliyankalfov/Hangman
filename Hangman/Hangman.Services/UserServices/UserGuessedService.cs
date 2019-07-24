using Hangman.Data;
using Hangman.Data.Models;
using Hangman.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hangman.Services.UserServices
{
    public class UserGuessedService : IUserGuessedService
    {
        private readonly ApplicationDbContext context;

        public UserGuessedService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void CreateUserGuessed(int userId, int wordId)
        {
            var field = new UserGuessed()
            {
                UserId = userId,
                WordId = wordId
            };
            if(!context.UsersGuessed.Contains(field))
            {
                context.UsersGuessed.Add(field);
                context.SaveChanges();
            }
        }

        public void DeleteAllUserGuessed()
        {
            var userGuessed = context.UsersGuessed;
            context.UsersGuessed.RemoveRange(userGuessed);
            context.SaveChanges();
        }

        //Personal stats(in progress)
        public List<UserGuessed> GetAllGuessedWordsWithGivenUserId(int userId)
        {
            var userGuessedList = context.UsersGuessed.Where(x => x.UserId == userId);
            return userGuessedList.ToList();
        }
        public List<string> GetAllWordsWithGivenUserIdDifficultyAndCategory(int userId, WordDifficulty wordDifficulty, int categoryId)
        {
            var list = new List<string>();
            var wordsGuessed = context.UsersGuessed.Where(x => x.UserId == userId).ToList();
            var words = context.Words.Where(x => x.WordDifficulty == wordDifficulty && x.CategoryId == categoryId);
            foreach (var wordG in wordsGuessed)
            {
                foreach (var word in words)
                {
                    if(word.Id == wordG.WordId )
                    {
                        list.Add(word.Name);
                    }
                }
            }
            return list;
        }
    }
}
