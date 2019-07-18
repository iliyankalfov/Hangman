using Hangman.Data;
using Hangman.Data.Models;
using Hangman.Data.Models.Enums;
using Hangman.Shared.InputModels.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hangman.Services
{
    public class WordService : IWordService
    {
        private readonly ApplicationDbContext context;

        public WordService(ApplicationDbContext context)
        {
            this.context = context;
        }

        //TODO: delete
        public void CreateWords()
        {
            List<string> easyWords = new List<string>() { "note", "drums" };
            List<string> mediumWords = new List<string>() { "guitar", "rhythm" };
            List<string> hardWords = new List<string>() { "saxophone", "performance" };
            if (!context.Words.Any())
            {
                for (int i = 0; i < easyWords.Count; i++)
                {
                    context.Words.Add(new Word { Name = easyWords[i], WordDifficulty = WordDifficulty.Easy, CategoryId = 3 });
                    context.SaveChanges();
                }
                for (int i = 0; i < mediumWords.Count; i++)
                {
                    context.Words.Add(new Word { Name = mediumWords[i], WordDifficulty = WordDifficulty.Medium, CategoryId = 3 });
                    context.SaveChanges();
                }
                for (int i = 0; i < hardWords.Count; i++)
                {
                    context.Words.Add(new Word { Name = hardWords[i], WordDifficulty = WordDifficulty.Hard, CategoryId = 3 });
                    context.SaveChanges();
                }
            }
        }

        public string GetRandomWord(WordDifficulty wordDifficulty, int categoryId)
        {
            int countOfWords = context.Words.Count(x => x.WordDifficulty == wordDifficulty && x.CategoryId == categoryId);
            if (!context.Words.Any())
            {
                throw new ArgumentException("There are no words in the database!");
            }
            int skippedWords = new Random().Next(countOfWords);
            var word = context.Words.Where(x=>x.WordDifficulty == wordDifficulty && x.CategoryId == categoryId)
            .Skip(skippedWords)
            .First().Name;
            return word;
        }

        public List<Word> GetAllWords()
        {
            if (!context.Words.Any())
            {
                throw new ArgumentException("There are no words in the database!");
            }
            var words = context.Words;
            return words.ToList();
        }

        //TODO: delete
        public void DeleteAllWords()
        {
            var words = context.Words;
            context.Words.RemoveRange(words);
            context.SaveChanges();
        }

        public int GetWordIdWithGivenName(string name)
        {
            var word = context.Words.FirstOrDefault(x => x.Name == name);
            return word.Id;
        }

        public WordDifficulty GetWordDifficultyWithGivenWordId(int wordId)
        {
            var word = context.Words.FirstOrDefault(x => x.Id == wordId);
            return word.WordDifficulty;
        }
    }
}
