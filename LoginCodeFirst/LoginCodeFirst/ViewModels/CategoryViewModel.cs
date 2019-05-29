using System.Collections.Generic;

namespace LoginCodeFirst.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set;  }
        public string CategoryName { get; set;  }
        
        public virtual ICollection<Models.Product> Products { get; set; }
    }
}