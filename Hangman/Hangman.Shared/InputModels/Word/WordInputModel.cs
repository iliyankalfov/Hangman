using Hangman.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Hangman.Shared.InputModels.Word
{
    public class WordInputModel
    {
        [Required]
        public string Name { get; set; }

        public WordDifficulty WordDifficulty { get; set; }
    }
}
