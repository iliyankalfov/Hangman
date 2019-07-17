using Blazor.Shared.Data;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Blazor.Clients
{
    public class ApiClient
    {
        private readonly HttpClient httpClient;

        public ApiClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        //Get methods
        public async Task<string> GetRandomWord(string wordDifficulty, int categoryId)
        {
            return await this.httpClient.GetStringAsync($"https://localhost:44382/api/word/{wordDifficulty}/{categoryId}");
        }

        public async Task<int> GetWordId(string wordDifficulty, int categoryId)
        {
            return await this.httpClient.GetJsonAsync<int>($"https://localhost:44382/api/word/GetWordId/{wordDifficulty}/{categoryId}");
        }

        public async Task<string> GetWordCategoryWithGivenId(int id)
        {
            return await this.httpClient.GetStringAsync($"https://localhost:44382/api/wordcategory/{id}");
        }

        public async Task<int> GetWordIdWithGivenName(string name)
        {
            return await this.httpClient.GetJsonAsync<int>($"https://localhost:44382/api/word/{name}");
        }

        public async Task<int> GetUserIdWithGivenEmailAndPassword(string email, string password)
        {
            return await this.httpClient.GetJsonAsync<int>($"https://localhost:44382/api/user/{email}/{password}");
        }

        public async Task<int> GetRandomCategoryId()
        {
            return await this.httpClient.GetJsonAsync<int>($"https://localhost:44382/api/wordcategory/GetRandomCategory");
        }

        /*public async Task<List<WordCategory>> GetCategories()
          {
              return await this.httpClient.GetJsonAsync<List<WordCategory>>($"https://localhost:44382/api/wordcategory");
          }*/

        //Post methods
        public async Task LoginUser(string email,string password)
        {
            User user = new User() { Email = email, Password = password };           
            await this.httpClient.PostJsonAsync($"https://localhost:44382/api/user/{email}/{password}",user);
        }

        public async Task CreateUserGuessedWord(int userId, int wordId)
        {
            UserGuessed userGuessed = new UserGuessed() { UserId = userId, WordId = wordId };
            await this.httpClient.PostJsonAsync($"https://localhost:44382/api/userguessed/{userId}/{wordId}", userGuessed);
        }

    }
}
