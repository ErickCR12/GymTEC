using System.ComponentModel.DataAnnotations;

namespace GymTEC_API.Models
{

    public class Employee
    {
       
        [Key]
        public int idCard {get; set;}
        [Key]
        public int idGym {get; set;}
        [Key]
        public int idJobPosition {get; set;}
        [Key]
        public int idPayroll {get; set;}
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
        public string province {get; set;}
        [Required]
        public string canton {get; set;}
        [Required]
        public string district {get; set;}
        [Required]
        public int salary {get; set;}
        
    }

}