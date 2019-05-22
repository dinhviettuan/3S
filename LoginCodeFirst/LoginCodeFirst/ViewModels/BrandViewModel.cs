using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace LoginCodeFirst.ViewModels.Brand
{
    public class BrandViewModel
    {
        [Display(Name = "Brand Id")]
        public int BrandId { get; set;  }
        [Display(Name = "Brand Id")]
        public string BrandName { get; set;  } 
        
        public virtual ICollection<Models.Product> Products { get; set; }
    }
}