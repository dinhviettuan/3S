using AutoMapper;

namespace LoginCodeFirst.ViewModels.Product
{
    public class Profiles : Profile 
    {
        public Profiles()
        {
            CreateMap<Models.Products.Product, IndexViewModel>();
           
        }
    }
}