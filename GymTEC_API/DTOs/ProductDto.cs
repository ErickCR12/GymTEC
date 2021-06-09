using System.ComponentModel.DataAnnotations;

namespace GymTEC_API.DTOs
{

    public class ProductDto
    {

        public int barCode {get; set;}
        public string name {get; set;}
        public string description {get; set;}
        public int price {get; set;}

        
    }

}