using Hangman.Data;
using Hangman.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hangman.Services.WordCategoryServices
{
    public class WordCategoryService : IWordCategoryService
    {
        private readonly ApplicationDbContext context;

        public WordCategoryService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void CreateACategory()
        {
            throw new NotImplementedException();
        }

        public void CreateCategories()
        {
            if(!context.WordCategories.Any())
            {
                List<WordCategory> categories = new List<WordCategory>()
                {
                    new WordCategory{ CategoryName = "Sports" },
                    new WordCategory{ CategoryName = "Fashion" },
                    new WordCategory{ CategoryName = "Music"}
                };
                foreach (var cat in categories)
                {
                    context.WordCategories.Add(cat);
                    context.SaveChanges();
                }
            }
        }

        /*public List<WordCategory> GetCategories()
        {
            if (!context.WordCategories.Any())
            {
                throw new ArgumentException("There are no word categories in the database!");
            }
            var wordCategories = context.WordCategories;
            context.SaveChanges();
            return wordCategories.ToList();
        }*/

        public string GetCategoryWithGivenId(int id)
        {
            var word = context.WordCategories.FirstOrDefault(x => x.Id == id);
            return word.CategoryName;
        }

        public int GetRandomCategory()
        {
            int rnd = new Random().Next(context.WordCategories.Count());
            return context.WordCategories.Skip(rnd).First().Id;
        }
    }
}
