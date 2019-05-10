using LoginCodeFirst.Models;
using LoginCodeFirst.Models.Products;

namespace LoginCodeFirst.ViewModels.Stock
{
    public class IndexViewModel
    {
        public int StoreId { get; set;  }
        public int ProductId { get; set;  }
        public int Quantity { get; set;  }
        
        public virtual Models.Products.Product Product { get; set; }
        public virtual Models.Store Store { get; set; }
    }
}