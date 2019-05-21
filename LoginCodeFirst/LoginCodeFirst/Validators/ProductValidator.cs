using FluentValidation;
using LoginCodeFirst.Models;
using LoginCodeFirst.Resources;
using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels.Product;
using Microsoft.Extensions.Localization;

namespace LoginCodeFirst.Validators.Product
{
    public class ProductValidator : AbstractValidator<ProductViewModel>
    {
        public ProductValidator(ResourcesServices<CommonResources> commonlocalizer,IProductServices productServices)
        {        
            RuleFor(x => x.ProductName).NotNull()
                .WithMessage(commonlocalizer.GetLocalizedHtmlString("msg_NotEmpty"));
            RuleFor(x => x.ModelYear).NotNull()
                .WithMessage(commonlocalizer.GetLocalizedHtmlString("msg_NotEmpty"));
            RuleFor(x => x.ListPrice).NotNull()
                .WithMessage(commonlocalizer.GetLocalizedHtmlString("msg_NotEmpty"));
            
            RuleFor(x => x.ProductName).Must((Reg,c) => !productServices.IsExistedName(Reg.ProductName,Reg.ProductId))
                .WithMessage((reg,c) => string.Format(commonlocalizer.GetLocalizedHtmlString("msg_AlreadyExists"),c));
            
            
        }
    }
}