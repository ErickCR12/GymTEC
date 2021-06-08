using System.ComponentModel.DataAnnotations;

namespace GymTEC_API.DTOs
{

    public class ExcerciseMachineDto
    {

        [Required]
        public int serialNumber {get; set;}
        public int idEquipment {get; set;}
        public string brand {get; set;}
        public int price {get; set;}

        
    }

}