using System.ComponentModel.DataAnnotations;

namespace GymTEC_API.DTOs
{

    public class ClassFilterDto
    {

        [Required]
        public int idGym {get; set;}
        public int idService {get; set;}
        public string startTime {get; set;}
        public string endTime {get; set;}
        public string date {get; set;}
    }

}