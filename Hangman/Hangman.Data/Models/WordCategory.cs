using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Hangman.Data.Models
{
    public class WordCategory : BaseModel<int>
    {
        [Required]
        public string CategoryName { get; set; }

    }
}
