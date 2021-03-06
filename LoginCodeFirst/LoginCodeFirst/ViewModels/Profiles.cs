﻿using AutoMapper;
using LoginCodeFirst.ViewModels.User;

namespace LoginCodeFirst.ViewModels
{
        public class Profiles : Profile
        {
            public Profiles()
            {
                CreateMap<Models.Category, CategoryViewModel>();
                CreateMap<Models.Product, ProductViewModel>();
                CreateMap<Models.Store, StoreViewModel>();
                CreateMap<Models.Stock,StockViewModel>();
                CreateMap<Models.Brand, BrandViewModel>();
                
                CreateMap<Models.User, LoginViewModel>();
                CreateMap<Models.User, PasswordViewModel>();
                CreateMap<Models.User, UserViewModel>();                
            }
        }
}