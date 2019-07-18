using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.Shared.Data
{
    public class User
    {
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }

        public int Points { get; set; }
    }
}
