using System;
using System.ComponentModel.DataAnnotations;

namespace GymTEC_API.Models
{

    public class GymClass
    {

        [Key]
        public int id {get; set;}
        [Required]
        public int idGym {get; set;}
        [Required]
        public int idService {get; set;}
        [Required]
        public int idInstructor {get; set;}
        [Required]
        public DateTime startTime {get; set;}
        [Required]
        public DateTime endTime {get; set;}
        [Required]
        public DateTime date {get; set;}
        [Required]
        public int capacity {get; set;}
        [Required]
        public bool isGroup {get; set;}
        
    }

}