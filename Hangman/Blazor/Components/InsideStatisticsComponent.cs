using Blazor.Shared.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.Components
{
    public class InsideStatisticsComponent : BaseClientComponent
    {
        public int UserId { get; set; } = 0;

        public int CategoryStatId { get; set; } = 1;

        public WordDifficulty WordDifficultyStat { get; set; } = WordDifficulty.Easy;

        public List<string> Words { get; set; } = new List<string>();

        public bool State { get; set; } = false;

        public async Task Navigate()
        {
            this.UriHelper.NavigateTo("/choice");
        }

        protected override async Task OnInitAsync()
        {
            this.Words.Clear();
        }

        public async Task GetStats()
        {
            var email = await JsInterop.GetSessionStorage("email");
            var password = await JsInterop.GetSessionStorage("password");
            var userId = await ApiClient.GetUserIdWithGivenEmailAndPassword(email, password);

            this.Words = await ApiClient.GetAllWordsWithGivenUserIdDifficultyAndCategory(userId, this.WordDifficultyStat, this.CategoryStatId);
            this.State = true;
        }
    }
}
