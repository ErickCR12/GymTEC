using System.ComponentModel.DataAnnotations;

namespace GymTEC_API.DTOs
{

    public class GymClassDto
    {

        [Required]
        public int id {get; set;}
        [Required]
        public int idService {get; set;}
        [Required]
        public int idInstructor {get; set;}
        [Required]
        public string startTime {get; set;}
        [Required]
        public string endTime {get; set;}
        [Required]
        public string date {get; set;}
        [Required]
        public int capacity {get; set;}
        [Required]
        public bool isGroup {get; set;}
        
    }

}