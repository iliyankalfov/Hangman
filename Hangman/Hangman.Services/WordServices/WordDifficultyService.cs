using Hangman.Data;
using Hangman.Data.Models;
using Hangman.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hangman.Services.WordServices
{
    public class WordDifficultyService : IWordDifficultyService
    {
        private readonly ApplicationDbContext context;

        public WordDifficultyService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void CreateWordDifficulties()
        {
            if(!context.WordDifficultyTables.Any())
            {
                var wordDiffs = new List<WordDifficultyTable>()
                {
                new WordDifficultyTable { Name = "Easy", Points = 2},
                new WordDifficultyTable { Name = "Medium", Points = 5},
                new WordDifficultyTable { Name = "Hard", Points = 8}
                };
                foreach (var wd in wordDiffs)
                {
                    context.WordDifficultyTables.Add(wd);
                    context.SaveChanges();
                }
            }

        }

        public int GetWordDifficultyId(int id)
        {
            var wordDifficulty = context.WordDifficultyTables.FirstOrDefault(x => x.Id == id);
            return wordDifficulty.Id;
        }

    }
}
