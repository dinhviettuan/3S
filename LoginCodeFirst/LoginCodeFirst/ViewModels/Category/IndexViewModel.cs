using System.Collections.Generic;
using LoginCodeFirst.Models.Products;

namespace LoginCodeFirst.ViewModels.Category
{
    public class IndexViewModel
    {
        public int CategoryId { get; set;  }
        public string CategoryName { get; set;  }
        
        public virtual ICollection<Models.Products.Product> Products { get; set; }
    }
}