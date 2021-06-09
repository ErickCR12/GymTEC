using System.ComponentModel.DataAnnotations;

namespace GymTEC_API.DTOs
{

    public class GymDto
    {

        [Required]
        public int id {get; set;}
        [Required]
        public int idAdmin {get; set;}
        [Required]
        public string name {get; set;}
        [Required]
        public int capacity {get; set;}
        [Required]
        public string province {get; set;}
        [Required]
        public string canton {get; set;}
        [Required]
        public string district {get; set;}
        [Required]
        public string openingTime {get; set;}
        [Required]
        public string closingTime {get; set;}
        [Required]
        public string openingDate {get; set;}
        [Required]
        public bool spaState {get; set;}
        [Required]
        public bool storeState {get; set;}
        
    }

}