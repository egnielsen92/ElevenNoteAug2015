using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElevenNote.Web.Models
{
    public class GuessingGameViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        [MinLength(2, ErrorMessage = "Must contain at least 2 letters")]
        [MaxLength(20, ErrorMessage = "Must contain no more than 20 letters")]
        [Display(Name = "Your Name")]
        public String Name { get; set; }

        [Required(ErrorMessage = "A guess is required")]
        [Range(1, 999, ErrorMessage = "Guess must be between 1 and 999")]
        [Display(Name = "Your Guess")]
        public int Guess { get; set; }

    }
}