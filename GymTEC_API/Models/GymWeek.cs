using System;
using System.ComponentModel.DataAnnotations;

namespace GymTEC_API.Models
{

    public class GymWeek
    {
        [Required]
        public DateTime startingDate {get; set;}
        [Required]
        public DateTime finishingDate {get; set;}
        [Required]
        public DateTime startingDateToCopy {get; set;}
        [Required]
        public DateTime finishingDateToCopy {get; set;}
    }

}