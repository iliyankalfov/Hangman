using System.ComponentModel.DataAnnotations;

namespace Hangman.ViewModels
{
    public class WordViewModel : BaseViewModel<int>
    {
        [Required]
        public string  Name { get; set; }

        public WordDifficultyModel WordDifficulty { get; set; }
    }
}
