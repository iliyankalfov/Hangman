using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.Shared.Data
{
    public class UserGuessed
    {
        [Required]
        public int UserId { get; set; }

        public int WordId { get; set; }
    }
}
