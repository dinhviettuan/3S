using System.Collections.Generic;

namespace LoginCodeFirst.ViewModels
{
    public class StoreViewModel
    {
        public int Id { get; set; }
        public string StoreName { get; set; } 
        public string Phone { get; set; } 
        public string Email { get; set; } 
        public string Street { get; set; } 
        public string City { get; set; } 
        public string State { get; set; } 
        public string ZipCode { get; set; } 
        
        public  virtual ICollection<Models.User> Users { get; set; }
        public virtual ICollection<Models.Stock> Stocks { get; set; }
        
    }
}


