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
            return await this.httpClient.GetJsonAsync<int>($"https://localhost:44382/api/word/GetWordIdWithGivenName/{name}");
        }

        public async Task<int> GetUserIdWithGivenEmailAndPassword(string email, string password)
        {
            return await this.httpClient.GetJsonAsync<int>($"https://localhost:44382/api/user/{email}/{password}");
        }

        public async Task<int> GetRandomCategoryId()
        {
            return await this.httpClient.GetJsonAsync<int>($"https://localhost:44382/api/wordcategory/GetRandomCategory");
        }

        public async Task<WordDifficulty> GetWordDifficultyWithGivenWordId(int wordId)
        {
            return await this.httpClient.GetJsonAsync<WordDifficulty>($"https://localhost:44382/api/word/GetWordDifficultyWithGivenWordId/{wordId}");
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await this.httpClient.GetJsonAsync<List<User>>($"https://localhost:44382/api/user/GetAllUsers");
        }

        public async Task<string> GetUser(int id)
        {
            return await this.httpClient.GetStringAsync($"https://localhost:44382/api/user/{id}");
        }

        public async Task<string> GetWordWithGivenId(int id)
        {
            return await this.httpClient.GetStringAsync($"https://localhost:44382/api/word/{id}");
        }

        /*public async Task<List<Word>> GetAllWordsWithGivenDifficultyAndCategoryId(WordDifficulty wordDifficulty, int categoryId)
        {
            return await this.httpClient.GetJsonAsync<List<Word>>($"https://localhost:44382/api/word/GetAllWordsWithGivenDifficultyAndCategoryId/{wordDifficulty}/{categoryId}");
        }*/
        /*public async Task<List<UserGuessed>> GetAllGuessedWordsWithGivenUserId(int userId)
        {
            return await this.httpClient.GetJsonAsync<List<UserGuessed>>($"https://localhost:44382/api/userguessed/{userId}");
        }*/
        /*public async Task<List<WordCategory>> GetCategories()
          {
              return await this.httpClient.GetJsonAsync<List<WordCategory>>($"https://localhost:44382/api/wordcategory");
          }*/

        //Post methods
        public async Task LoginUser(string email,string password)
        {
            try
            {
                User user = new User() { Email = email, Password = password };           
                await this.httpClient.PostJsonAsync($"https://localhost:44382/api/user/{email}/{password}",user);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException("Enter another email!");
            }

        }

        public async Task CreateUserGuessedWord(int userId, int wordId)
        {
            UserGuessed userGuessed = new UserGuessed() { UserId = userId, WordId = wordId };
            await this.httpClient.PostJsonAsync($"https://localhost:44382/api/userguessed/{userId}/{wordId}", userGuessed);
        }

        //Put methods
        public async Task UpdateUserPointsWithGivenUserIdAndPoints(int userId, int points)
        {
            var user = await this.httpClient.GetJsonAsync<User>($"https://localhost:44382/api/user/{userId}");
            await this.httpClient.PutJsonAsync($"https://localhost:44382/api/user/{userId}/{points}",user);
        }

    }
}
