using System.ComponentModel.DataAnnotations;

namespace GymTEC_API.Models
{

    public class ExcerciseMachine
    {

        [Key]
        public int serialNumber {get; set;}
        [Required]
        public int idEquipment {get; set;}
        [Required]
        public string brand {get; set;}
        [Required]
        public int price {get; set;}

        
    }

}