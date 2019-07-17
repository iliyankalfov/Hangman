using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.Shared.Data
{
    public class WordCategory
    {
        [Required]
        public string CategoryName { get; set; }

        [Key]
        public int Id { get; set; }
    }
}
