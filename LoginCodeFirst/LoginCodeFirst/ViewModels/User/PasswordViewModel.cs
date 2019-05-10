

namespace LoginCodeFirst.ViewModels.User
{
    public class PasswordViewModel
    {
        public PasswordViewModel()
        {
            
        }
        
        public PasswordViewModel(Models.User user)
        {
            UserId = user.UserId;
            Password = user.Password;
        }
        
        public int UserId { get; }
        public string Password { get; } 
    }
}