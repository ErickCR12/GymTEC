using System.ComponentModel.DataAnnotations;

namespace GymTEC_API.Models{

    public class LoginProfile
    {
        [Required]
        public int Username { get; set;}
        
        [Required]
        public string Password { get; set;}

        public string UserType{ get; set;}
    }
}