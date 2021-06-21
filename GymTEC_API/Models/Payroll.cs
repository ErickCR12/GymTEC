using System.ComponentModel.DataAnnotations;

namespace GymTEC_API.Models
{

    public class Payroll
    {

        [Key]
        public int id {get; set;}
        [Required]
        public string description {get; set;}
        public int hourlyPay {get; set;}
        public int monthlyPay {get; set;}
        public int payPerClass {get; set;}
        
    }

}