using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LoginCodeFirst.ViewModels
{
    public class CategoryViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set;  }
        
        [Display(Name = "Category Name")]
        public string CategoryName { get; set;  }
        
        public virtual ICollection<Models.Product> Products { get; set; }
    }
}