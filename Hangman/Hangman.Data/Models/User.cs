using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Hangman.Data.Models
{
    public class User : BaseModel<int>
    {
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
        public int Points { get; set; }
    }
}
