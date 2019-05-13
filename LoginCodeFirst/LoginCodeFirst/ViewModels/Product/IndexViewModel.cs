using System.Collections.Generic;
using LoginCodeFirst.Models.Products;

namespace LoginCodeFirst.ViewModels.Product
{
    public class IndexViewModel
    {
        public int ProductId { get; set;  }
        public string ProductName { get; set;  }
        public int   BrandId { get; set;  }
        public int   CategoryId { get; set;  }
        public int ModelYear { get; set;  }
        public decimal ListPrice { get; set;  }
        public string Image { get; set; }
        
        public virtual Models.Products.Category Category { get; set; }
        public virtual Models.Products.Brand Brand { get; set; }
        public virtual ICollection<Models.Products.Stock> Stocks { get; set; }
    }
}