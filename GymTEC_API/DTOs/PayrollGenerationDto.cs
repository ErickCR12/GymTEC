using System.ComponentModel.DataAnnotations;

namespace GymTEC_API.Models
{

    public class PayrollGenerationDto
    {

        [Required]
        public int gymId {get; set;}
        [Required]
        public int idCard {get; set;}
        [Required]
        public string name {get; set;}
        [Required]
        public string last_name1 {get; set;}
        [Required]
        public string last_name2 {get; set;}
        [Required]
        public int classesHours {get; set;}
        [Required]
        public int salary {get; set;}
        
    }

}