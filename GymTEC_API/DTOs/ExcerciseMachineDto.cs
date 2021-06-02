using System.ComponentModel.DataAnnotations;

namespace GymTEC_API.DTOs
{

    public class ExcerciseMachineDto
    {

        [Required]
        public int serialNumber {get; set;}
        [Required]
        public string idEquipment {get; set;}
        [Required]
        public string brand {get; set;}
        [Required]
        public int price {get; set;}

        
    }

}