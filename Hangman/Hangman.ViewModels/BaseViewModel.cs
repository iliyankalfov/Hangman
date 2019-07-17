using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Hangman.ViewModels
{
    public class BaseViewModel<T>
    {
        [Key]
        public T Id { get; set; }

    }
}
