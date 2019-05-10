using AutoMapper;
using LoginCodeFirst.Models;
using LoginCodeFirst.ViewModels.User;


namespace LoginCodeFirst.ViewModels.User
{
    public class Profiles : Profile
        {
            public Profiles()
            {
                CreateMap<Models.User, LoginViewModel>();
                CreateMap<Models.User, PasswordViewModel>();
                CreateMap<Models.User, IndexViewModel>();
            }
        }
}