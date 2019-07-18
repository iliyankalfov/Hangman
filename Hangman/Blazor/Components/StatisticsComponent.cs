using Blazor.Shared.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.Components
{
    public class StatisticsComponent : BaseClientComponent
    {

        public List<string> Emails { get; set; } = new List<string>();

        public List<User> Users { get; set; } = new List<User>();

        public int Counter { get; set; } = 1;

        protected override async Task OnInitAsync()
        {
            var users = await ApiClient.GetAllUsers();
            this.Users = users;
        }      
        

    }
}
