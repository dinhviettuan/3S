using AutoMapper;

namespace LoginCodeFirst.ViewModels.Store
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<Models.Store, IndexViewModel>();
        }
    }
}