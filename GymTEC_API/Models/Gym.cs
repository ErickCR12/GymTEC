using System;
using System.ComponentModel.DataAnnotations;

namespace GymTEC_API.Models
{

    public class Gym
    {

        [Key]
        public int id {get; set;}
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
        public DateTime openingTime {get; set;}
        [Required]
        public DateTime closingTime {get; set;}
        [Required]
        public DateTime openingDate {get; set;}
        [Required]
        public bool spaState {get; set;}
        [Required]
        public bool storeState {get; set;}
        
    }

}