using System.Collections.Generic;


namespace LoginCodeFirst.ViewModels.Brand
{
    public class BrandViewModel
    {
        public int BrandId { get; set;  }
        public string BrandName { get; set;  } 
        
        public virtual ICollection<Models.Product> Products { get; set; }
    }
}