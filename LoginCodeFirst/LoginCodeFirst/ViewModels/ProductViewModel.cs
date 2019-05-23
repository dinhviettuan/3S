using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace LoginCodeFirst.ViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set;  }
        public string ProductName { get; set;  }
        public int   BrandId { get; set;  }
        public int   CategoryId { get; set;  }
        public int ModelYear { get; set;  }
        public decimal ListPrice { get; set;  }
        public string Image { get; set;  }
        public IFormFile ImageFile { get; set; }
        
        public virtual Models.Category Category { get; set; }
        public virtual Models.Brand Brand { get; set; }
        public virtual ICollection<Models.Stock> Stocks { get; set; }
    }
}