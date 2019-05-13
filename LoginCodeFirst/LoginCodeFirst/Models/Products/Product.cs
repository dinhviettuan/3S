using System.Collections.Generic;

namespace LoginCodeFirst.Models.Products
{
    public class Product
    {
        public int ProductId { get; set;  }
        public string ProductName { get; set;  }
        public int   BrandId { get; set;  }
        public int   CategoryId { get; set;  }
        public int ModelYear { get; set;  }
        public decimal ListPrice { get; set;  }
        public  string Image { get; set; }
        
        public virtual Category Category { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
    }
}