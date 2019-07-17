using System.ComponentModel.DataAnnotations;

namespace Hangman.Data.Models
{
    public class BaseModel<T>
    {
        [Key]
        public T Id { get; set; }
    }
}
