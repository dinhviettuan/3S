using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace LoginCodeFirst.ViewModels
{
    public class ProductViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set;  }
        
        [Display(Name = "Product Name")]
        public string ProductName { get; set;  }
        
        [Display(Name = "Brand Id")]
        public int   BrandId { get; set;  }
        
        [Display(Name = "Category Id")]
        public int   CategoryId { get; set;  }
        
        [Display(Name = "ModelYear")]
        public int ModelYear { get; set;  }
        
        [Display(Name = "List Price")]
        public decimal ListPrice { get; set;  }
        
        public string Image { get; set;  }
        public IFormFile ImageFile { get; set; }
        
        public virtual Models.Category Category { get; set; }
        public virtual Models.Brand Brand { get; set; }
        public virtual ICollection<Models.Stock> Stocks { get; set; }
    }
}