using Hangman.Data.Models;
using Hangman.Data.Models.Enums;
using Hangman.Shared.InputModels.Word;
using Hangman.ViewModels;
using System.Collections.Generic;

namespace Hangman.Services
{
    public interface IWordService
    {
        void CreateWords();

        string GetRandomWord(WordDifficulty wordDifficulty, int categortId);

        List<Word> GetAllWords();

        void DeleteAllWords();

        int GetWordIdWithGivenName(string name);
    }
}
