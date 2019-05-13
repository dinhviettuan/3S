using FluentValidation;
using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels.Brand;
using Microsoft.Extensions.Localization;

namespace LoginCodeFirst.Validators.Brand
{
    public class IndexValidator : AbstractValidator<IndexViewModel>
    {
        public IndexValidator(IBrandServices brandServices, IStringLocalizer<IndexViewModel> localizer)
        {
            var brands = brandServices.GetBrands();
            foreach (var brand in brands)
            {

                RuleFor(x => x.BrandName).NotEqual(brand.BrandName).WithMessage(localizer["This BrandName already exists."]);

            }
            RuleFor(x => x.BrandName).NotNull().WithMessage(localizer["BrandName not be empty"]);
            RuleFor(x => x.BrandName).NotNull().WithMessage(localizer["Start with letters"]);
        }
    }
}
