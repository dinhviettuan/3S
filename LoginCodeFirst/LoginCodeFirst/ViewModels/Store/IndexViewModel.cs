﻿using System.Collections.Generic;
using LoginCodeFirst.Models.Products;

namespace LoginCodeFirst.ViewModels.Store
{
    public class IndexViewModel
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; } 
        public string Phone { get; set; } 
        public string Email { get; set; } 
        public string Street { get; set; } 
        public string City { get; set; } 
        public string State { get; set; } 
        public string ZipCode { get; set; } 
        
        public  virtual ICollection<Models.User> Users { get; set; }
        public virtual ICollection<Models.Products.Stock> Stocks { get; set; }
        
    }
}

