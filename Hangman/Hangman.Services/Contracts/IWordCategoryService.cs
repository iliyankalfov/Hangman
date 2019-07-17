using Hangman.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman.Services.WordCategoryServices
{
    public interface IWordCategoryService
    {
        void CreateCategories();

        void CreateACategory();

        //List<WordCategory> GetCategories();
        string GetCategoryWithGivenId(int id);

        int GetRandomCategory();
    }
}
