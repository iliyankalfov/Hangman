using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.Components
{
    public class InsideStatisticsComponent : BaseClientComponent
    {
        public int UserId { get; set; } = 0;

        public List<string> Words { get; set; } = new List<string>();

        protected override async Task OnInitAsync()
        {
            this.UserId = sessionStats.UserId;
            this.Words = sessionStats.Words;
            Console.WriteLine(this.Words);
        }

        public async Task Navigate()
        {
            this.UriHelper.NavigateTo("/choice");
        }
    }
}
