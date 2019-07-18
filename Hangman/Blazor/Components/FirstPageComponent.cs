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

        public List<User> Users { get; set; } = new List<User>();

        protected override async Task OnInitAsync()
        {
            this.Users = await ApiClient.GetAllUsers();
        }

        public async Task StartGame()
        {
            SessionClass.wordDifficulty = this.wordDifficulty;
            SessionClass.categoryId = this.categoryId;
            this.UriHelper.NavigateTo("/startgame");
        }

        public async Task Navigate()
        {
            this.Users = await ApiClient.GetAllUsers();
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
    }
}
