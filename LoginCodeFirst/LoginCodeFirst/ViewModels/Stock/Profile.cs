using AutoMapper;
using LoginCodeFirst.Models.Products;

namespace LoginCodeFirst.ViewModels.Stock
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            
            CreateMap<Models.Products.Stock,IndexViewModel>();
        }
    }
}
