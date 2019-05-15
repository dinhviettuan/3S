using FluentValidation;
using LoginCodeFirst.Models;
using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels.Product;
using Microsoft.Extensions.Localization;

namespace LoginCodeFirst.Validators.Product
{
    public class ProductValidator : AbstractValidator<ProductViewModel>
    {
        public ProductValidator(IProductServices productServices, IStringLocalizer<ProductViewModel> localizer)
        {          
            RuleFor(x => x.ProductName).Must((Reg,c) => !productServices.IsExistedName(Reg.ProductName,Reg.ProductId))
                .WithMessage(localizer["This ProductName already exists."]);            
            RuleFor(x => x.ProductName).NotNull()
                .WithMessage(localizer["ProductName not be empty"]);
            RuleFor(x => x.ModelYear).NotNull()
                .WithMessage(localizer["ModelYear not be empty"]);
            RuleFor(x => x.ListPrice).NotNull()
                .WithMessage(localizer["ListPrice not be empty"]);
        }
    }
}