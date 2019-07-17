using Hangman.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hangman.Data.Models
{
    public class Word : BaseModel<int>
    {
        [Required]
        public string Name { get; set; }

        public WordDifficulty WordDifficulty { get; set; }

        //[ForeignKey("Id")]
        public int CategoryId { get; set; }
    }
}
