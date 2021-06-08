using System.ComponentModel.DataAnnotations;

namespace GymTEC_API.DTOs
{

    public class GymServiceDto
    {

        [Required]
        public int id {get; set;}
        public string name {get; set;}
        
    }

}