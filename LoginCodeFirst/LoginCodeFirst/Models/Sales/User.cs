using System.ComponentModel.DataAnnotations;

namespace LoginCodeFirst.Models
{
    public class User
    {
//    public User()
//    {
//    }
//        public User(int UserId, string Email, string Password, string Fullname,int StoreId, string Phone,bool IsActive)
//        {
//            UserId = UserId;
//            StoreId = StoreId;
//            Email = Email;
//            Password = Password;
//            Fullname = Fullname;
//            Phone = Phone;
//            IsActive = IsActive;
//        }

        public int UserId { get; set; }
        public int StoreId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        
        public  virtual Store Store { get; set; }
    }
}