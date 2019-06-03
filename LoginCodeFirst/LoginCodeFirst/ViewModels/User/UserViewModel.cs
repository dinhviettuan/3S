using System.ComponentModel.DataAnnotations;

namespace LoginCodeFirst.ViewModels.User
{
        public class UserViewModel
        {
            [Display(Name = "Id")]
            public int Id { get; set; }
            
            [Display(Name = "Email")]
            public string Email { get; set; }
            
            [Display(Name = "Password")]
            public string Password { get; set; }
            
            [Display(Name = "Full Name")]
            public string FullName { get; set; }
            
            [Display(Name = "Phone")]
            public string Phone { get; set; }
            
            [Display(Name = "Role")]
            public int Role { get; set; }
            
            [Display(Name = "Store Id")]
            public int StoreId { get; set; }
            
            [Display(Name = "IsActive")]
            public bool IsActive { get; set; }
            
            public Models.Store Store { get; set; }
        }
}