using FluentValidation;
using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels.Category;
using Microsoft.Extensions.Localization;

namespace LoginCodeFirst.Validators.CategoryValidator
{
    public class CategoryValidator : AbstractValidator<CategoryViewModel>
    {
        public CategoryValidator(ICategoryServices categoryServices, IStringLocalizer<CategoryViewModel> localizer)
        { 
                
            RuleFor(x => x.CategoryName).Must((Reg,c) => !categoryServices.IsExistedName(Reg.CategoryName,Reg.CategoryId))
                    .WithMessage(localizer["This CategoryName already exists."]);
            RuleFor(x => x.CategoryName).NotNull()
                    .WithMessage(localizer["CategoryName not be empty"]);
            RuleFor(x => x.CategoryName).NotNull()
                    .WithMessage(localizer["Start with letters"]);
        }
    }
}
