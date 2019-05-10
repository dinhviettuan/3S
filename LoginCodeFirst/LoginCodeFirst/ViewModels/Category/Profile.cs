using AutoMapper;


namespace LoginCodeFirst.ViewModels.Category
{
        public class Profiles : Profile
        {
            public Profiles()
            {
                CreateMap<Models.Products.Category, IndexViewModel>();
            }
        }
}