using System.ComponentModel.DataAnnotations;

namespace GymTEC_API.Models
{

    public class GymService
    {

        [Key]
        public int id {get; set;}
        [Required]
        public string name {get; set;}
        
    }

}