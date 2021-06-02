using System.ComponentModel.DataAnnotations;

namespace GymTEC_API.DTOs
{

    public class GymServiceDto
    {

        [Required]
        public int id {get; set;}
        [Required]
        public string name {get; set;}
        
    }

}