using System.ComponentModel.DataAnnotations;

namespace LoginCodeFirst.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Email")]
        public string Email { get; set;  }
        
        [Display(Name = "Password")]
        public string Password { get; set; } 
    }
}