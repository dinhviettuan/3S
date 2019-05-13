using FluentValidation;
using LoginCodeFirst.Models;
using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels.Product;
using Microsoft.Extensions.Localization;

namespace LoginCodeFirst.Validators.Product
{
    public class IndexValidator : AbstractValidator<IndexViewModel>
    {
        public IndexValidator(IProductServices productServices, IStringLocalizer<IndexViewModel> localizer)
        {
            RuleFor(x => x.ProductName).NotNull().WithMessage(localizer["ProductName not be empty"]);
            RuleFor(x => x.ModelYear).NotNull().WithMessage(localizer["ModelYear not be empty"]);
            RuleFor(x => x.ListPrice).NotNull().WithMessage(localizer["ListPrice not be empty"]);
        }
    }
}