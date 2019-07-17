using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman.Data.Models
{
    public class WordDifficultyTable : BaseModel<int>
    {
        public string Name { get; set; }

        public int Points { get; set; }
    }
}
