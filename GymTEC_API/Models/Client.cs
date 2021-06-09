using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GymTEC_API.Models
{

    public class Client
    {
        
        [BsonId]
        public ObjectId Id {get; set;} 
        [Key]
        public int idCard {get; set;}
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
        public DateTime birthday {get; set;}
        [Required]
        public int weight {get; set;}
        [Required]
        public double IMC {get; set;}
        
    }

}