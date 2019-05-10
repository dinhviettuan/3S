﻿using System.Collections;

namespace LoginCodeFirst.ViewModels.User
{
        public class IndexViewModel
        {
            public int UserId { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string FullName { get; set; }
            public string Phone { get; set; }
            public int StoreId { get; set; }
            public bool IsActive { get; set; }
            
            public  virtual Models.Store Store { get; set; }
            
        }
}