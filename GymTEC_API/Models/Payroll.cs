using System.ComponentModel.DataAnnotations;

namespace GymTEC_API.Models
{

    public class Payroll
    {

        [Key]
        public int id {get; set;}
        [Required]
        public string description {get; set;}
        [Required]
        public int hourlyPay {get; set;}
        [Required]
        public int monthlyPay {get; set;}
        [Required]
        public int payPerClass {get; set;}
        
    }

}