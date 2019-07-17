using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.Components
{
    public class LoginComponent : BaseClientComponent
    {
        public string Email { get; set; } = "";

        public string Password { get; set; } = "";

        public async Task Login()
        {
            await ApiClient.LoginUser(this.Email, this.Password);
            await JsInterop.SetSessionStorage("email", this.Email);
            await JsInterop.SetSessionStorage("password", this.Password);
            Navigate();
        }
        public void Navigate()
        {
            UriHelper.NavigateTo("/choice");
        }
    }
}
