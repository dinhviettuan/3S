using AutoMapper;
using LoginCodeFirst.ViewModels.Brand;

namespace LoginCodeFirst.ViewModels.Brand
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<Models.Products.Brand, IndexViewModel>();
        }
    }
}