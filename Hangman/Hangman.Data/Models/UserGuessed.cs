using System.ComponentModel.DataAnnotations;

namespace Hangman.Data.Models
{
    public class UserGuessed : BaseModel<int>
    {
        [Required]
        public int UserId { get; set; }

        public int WordId { get; set; }
    }
}
