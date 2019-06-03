using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace LoginCodeFirst.ViewModels
{
    public class BrandViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set;  }
        
        [Display(Name = "Brand Name")]
        public string BrandName { get; set;  } 
        
        public virtual ICollection<Models.Product> Products { get; set; }
    }
}