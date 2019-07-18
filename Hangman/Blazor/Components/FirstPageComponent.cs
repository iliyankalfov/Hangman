using Blazor.Clients;
using Blazor.Shared.Data;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.Components
{
    public class FirstPageComponent : BaseClientComponent
    {
        public WordDifficulty wordDifficulty { get; set; } = WordDifficulty.Easy;

        public int categoryId { get; set; } = 1;
        public int CategoryStat { get; set; } = 0;
        public WordDifficulty WordDifficultyStat { get; set; }
        public int UserId { get; set; } = 0;

        public List<string> WordList { get; set; } = new List<string>();

        public async Task StartGame()
        {
            SessionClass.wordDifficulty = this.wordDifficulty;
            SessionClass.categoryId = this.categoryId;
            this.UriHelper.NavigateTo("/startgame");
        }
        
        public void NavigateToChoisePage()
        {
            UriHelper.NavigateTo("/choice");
        }
        public void NavigateToLoginPage()
        {
            UriHelper.NavigateTo("/");
        }

        public void RandomWordDifficulty()
        {           
            Array values = Enum.GetValues(typeof(WordDifficulty));
            Random random = new Random();
            WordDifficulty randomWordDifficulty = (WordDifficulty)values.GetValue(random.Next(values.Length));
            this.wordDifficulty = randomWordDifficulty;
        }
        public async Task RandomCategory()
        {
            this.categoryId = await ApiClient.GetRandomCategoryId();
        }

        protected override async Task OnInitAsync()
        {
            var email = await JsInterop.GetSessionStorage("email");
            var password = await JsInterop.GetSessionStorage("password");
            var userId = await ApiClient.GetUserIdWithGivenEmailAndPassword(email, password);
            this.WordDifficultyStat = SessionClass.wordDifficulty;
            this.CategoryStat = SessionClass.categoryId;
        }

        public async Task GetStats()
        {
            var wordList = await ApiClient.GetAllWordsWithGivenDifficultyAndCategoryId(WordDifficultyStat, CategoryStat);
            var userGuessedList = await ApiClient.GetAllGuessedWordsWithGivenUserId(this.UserId);
            for (int i = 0; i < userGuessedList.Count; i++)
            {
                foreach (var word in wordList)
                {
                    var wordId = await ApiClient.GetWordIdWithGivenName(word.Name);
                    if(userGuessedList[i].WordId==wordId)
                    {
                        this.WordList.Add(word.Name);
                    }
                }
            }
        }
    }
}
