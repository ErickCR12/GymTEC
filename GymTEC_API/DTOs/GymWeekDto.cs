using System;
using System.ComponentModel.DataAnnotations;

namespace GymTEC_API.DTOs
{

    public class GymWeekDto
    {
        [Required]
        public string startingDate {get; set;}
        [Required]
        public string finishingDate {get; set;}
        [Required]
        public string startingDateToCopy {get; set;}
        [Required]
        public string finishingDateToCopy {get; set;}
    }

}