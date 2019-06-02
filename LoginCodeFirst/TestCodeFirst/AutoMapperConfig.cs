using AutoMapper;
using LoginCodeFirst.Models;
using LoginCodeFirst.ViewModels;
using LoginCodeFirst.ViewModels.User;

namespace TestCodeFirst
{
    public static class AutoMapperConfig
    {
        private static readonly object ThisLock = new object();
        private static bool _initialized;

        private static IMapper _mapper;
        // Centralize automapper initialize
        public static void Initialize()
        {
            // This will ensure one thread can access to this static initialize call
            // and ensure the mapper is reseted before initialized
            lock (ThisLock)
            {
                if (!_initialized)
                {
                    var config = new MapperConfiguration(opts =>
                    {
                        opts.CreateMap<Brand, BrandViewModel>(); 
                        opts.CreateMap<Category, CategoryViewModel>();
                        opts.CreateMap<Product, ProductViewModel>();
                        opts.CreateMap<Store, StoreViewModel>();
                        opts.CreateMap<Stock,StockViewModel>();
                
                        opts.CreateMap<User, LoginViewModel>();
                        opts.CreateMap<User, PasswordViewModel>();
                        opts.CreateMap<User, UserViewModel>();   
                    });
                    _initialized = true;
                    _mapper = config.CreateMapper();
                }
            }
        }
        public static IMapper GetMapper()
        {
            return _mapper;
        }
    }
}