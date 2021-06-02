using System.ComponentModel.DataAnnotations;

namespace GymTEC_API.DTOs
{

    public class ClientDto
    {
        [Required]
        public int idCard {get; set;}
        [Required]
        public string email {get; set;}
        [Required]
        public string password {get; set;}
        [Required]
        public string name {get; set;}
        [Required]
        public string last_name1 {get; set;}
        [Required]
        public string last_name2 {get; set;}
        [Required]
        public string country {get; set;}
        [Required]
        public string continent {get; set;}
        [Required]
        public string district {get; set;}
        [Required]
        public string birthday {get; set;}
        [Required]
        public int weight {get; set;}
        [Required]
        public int IMC {get; set;}
        
    }

}