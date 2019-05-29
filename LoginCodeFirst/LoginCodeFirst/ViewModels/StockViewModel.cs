namespace LoginCodeFirst.ViewModels
{
    public class StockViewModel
    {
        public int StoreId { get; set;  }
        public int ProductId { get; set;  }
        public int Quantity { get; set;  }
        
        public virtual Models.Product Product { get; set; }
        public virtual Models.Store Store { get; set; }
    }
}