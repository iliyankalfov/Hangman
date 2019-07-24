using Hangman.Data.Models;
using Hangman.Data.Models.Enums;
using Hangman.Services.UserServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hangman.WebApi.Controllers
{
    public class UserGuessedController : ApiController
    {
        private readonly IUserGuessedService userGuessedService;

        public UserGuessedController(IUserGuessedService userGuessedService)
        {
            this.userGuessedService = userGuessedService;
        }

        [HttpPost("{userId}/{wordId}")]
        public ActionResult CreateUserGuessed(int userId, int wordId)
        {
            userGuessedService.CreateUserGuessed(userId, wordId);
            return this.Ok();
        }

        [HttpDelete]
        public ActionResult DeleteAllUserGuessed()
        {
            userGuessedService.DeleteAllUserGuessed();
            return this.Ok();
        }

        //Personal stats(in progress)
        [HttpGet("{userId}")]
        public ActionResult<List<UserGuessed>> GetAllGuessedWordsWithGivenUserId(int userId)
        {
            return userGuessedService.GetAllGuessedWordsWithGivenUserId(userId);
        }

        [HttpGet("{userId}/{wordDifficulty}/{categoryId}")]
        public ActionResult<List<string>> GetAllWordsWithGivenUserIdDifficultyAndCategory(int userId, WordDifficulty wordDifficulty, int categoryId)
        {
            return userGuessedService.GetAllWordsWithGivenUserIdDifficultyAndCategory(userId, wordDifficulty, categoryId);
        }
    }
}
