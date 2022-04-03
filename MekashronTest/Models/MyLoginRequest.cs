using System.ComponentModel.DataAnnotations;

namespace MekashronTest.Models
{
    public class MyLoginRequest
    {
        [Required(ErrorMessage ="UserName is not null")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is not null")]
        public string Password { get; set; }
    }
}
