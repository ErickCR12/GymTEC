using System.ComponentModel.DataAnnotations;

namespace GymTEC_API.Models
{

    public class Product
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