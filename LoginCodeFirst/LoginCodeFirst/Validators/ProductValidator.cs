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
        public ProductValidator(ResourcesServices<ProductResources> localizer,IProductServices productServices)
        {          
            RuleFor(x => x.ProductName).Must((Reg,c) => !productServices.IsExistedName(Reg.ProductName,Reg.ProductId))
                .WithMessage(localizer.GetLocalizedHtmlString("lbl_ThisProductNameAlreadyExists"));            
            RuleFor(x => x.ProductName).NotNull()
                .WithMessage(localizer.GetLocalizedHtmlString("lbl_ProductNameNotBeEmpty"));
            RuleFor(x => x.ModelYear).NotNull()
                .WithMessage(localizer.GetLocalizedHtmlString("lbl_ModelYearNotBeEmpty"));
            RuleFor(x => x.ListPrice).NotNull()
                .WithMessage(localizer.GetLocalizedHtmlString("lbl_ListPriceNotBeEmpty"));
        }
    }
}