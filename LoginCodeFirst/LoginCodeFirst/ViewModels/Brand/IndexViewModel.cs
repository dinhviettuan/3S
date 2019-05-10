using System.Collections.Generic;


namespace LoginCodeFirst.ViewModels.Brand
{
    public class IndexViewModel
    {
        public int BrandId { get; set;  }
        public string BrandName { get; set;  } 
        
        public virtual ICollection<Models.Products.Product> Products { get; set; }
    }
}