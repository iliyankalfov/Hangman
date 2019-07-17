﻿using Hangman.Data;
using Hangman.Data.Models;
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
    }
}
