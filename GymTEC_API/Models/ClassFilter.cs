using System;
using System.ComponentModel.DataAnnotations;

namespace GymTEC_API.Models
{

    public class ClassFilter
    {

        [Required]
        public int idGym {get; set;}
        public int idService {get; set;}
        public DateTime? startTime {get; set;}
        public DateTime? endTime {get; set;}
        public DateTime? date {get; set;}
    }

}