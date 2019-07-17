using Hangman.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman.Services.WordServices
{
    public interface IWordDifficultyService
    {
        void CreateWordDifficulties();
        int GetWordDifficultyId(int id);
    }
}
