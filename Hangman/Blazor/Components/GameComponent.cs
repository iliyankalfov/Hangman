using Blazor.Clients;
using Blazor.Shared.Data;
using GameLogic;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.Components
{
    public class GameComponent : BaseClientComponent
    {
        [Inject]
        public Game game { get; set; }

        public string CategoryName { get; set; }
        public WordDifficulty WordDifficulty { get; set; }
        public string Letter { get; set; } = "";
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public string Word { get; set; } = "";
        public int UserId { get; set; } = 0;
        public int WordId { get; set; } = 0;
        public int Points { get; set; } = 0;


        protected override async Task OnInitAsync() => await NewWord();

        public void UseJoker()
        {            
            this.game.UseJoker();
        }

        public async Task Guess()
        {
            this.game.GuessingLetter(this.Letter);
            if(this.game.gameTracker.GameOver())
            {
                NavigateToGameOver();
            }
            if (this.game.guessingWord == this.game.realWord)
            {
                var userId = await ApiClient.GetUserIdWithGivenEmailAndPassword(this.Email, this.Password);
                var wordId = await ApiClient.GetWordIdWithGivenName(this.Word);

                await ApiClient.CreateUserGuessedWord(userId, wordId);
                await AddPoints(userId,this.WordDifficulty);
            }
        }

        private async Task NewWord()
        {
            var difficulty = SessionClass.wordDifficulty;
            
            this.WordDifficulty = difficulty;
            //this.Points = await ApiClient.GetPointsOfAWordDifficultyWithGivenWordDifficulty(Enum.GetName(typeof(WordDifficulty),difficulty));

            var categoryId = SessionClass.categoryId;
            var category = await ApiClient.GetWordCategoryWithGivenId(categoryId);
            this.CategoryName = category;

            this.Word = await ApiClient.GetRandomWord(this.WordDifficulty.ToString(),categoryId);
            this.Email = await JsInterop.GetSessionStorage("email");
            this.Password = await JsInterop.GetSessionStorage("password");

            game.InitializingWord(this.Word);
            game.gameTracker.ResetScore();
        }

        public void NewGame()
        {
            UriHelper.NavigateTo("/choice");
        }

        public void NavigateToGameOver()
        {
            UriHelper.NavigateTo("/gameover");
        }

        public async Task AddPoints(int userId,WordDifficulty wordDifficulty)
        {
            int points = 0;
            switch (wordDifficulty.ToString())
            {
                case "Easy": points = 2;
                    break;
                case "Medium": points = 5;
                    break;
                case "Hard": points = 8;
                    break;
                default:
                    break;
            }
            //this.Points += points;
            await ApiClient.UpdateUserPointsWithGivenUserIdAndPoints(userId, points);
        }
    }
}
