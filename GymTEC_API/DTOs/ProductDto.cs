using System.ComponentModel.DataAnnotations;

namespace GymTEC_API.DTOs
{

    public class ProductDto
    {

        [Key]
        public int barCode {get; set;}
        [Required]
        public string name {get; set;}
        [Required]
        public string description {get; set;}
        [Required]
        public int price {get; set;}

        
    }

}