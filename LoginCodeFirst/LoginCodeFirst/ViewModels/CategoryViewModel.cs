using System.Collections.Generic;

namespace LoginCodeFirst.ViewModels.Category
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set;  }
        public string CategoryName { get; set;  }
        
        public virtual ICollection<Models.Product> Products { get; set; }
    }
}