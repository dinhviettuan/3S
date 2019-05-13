using FluentValidation;
using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels.Category;
using Microsoft.Extensions.Localization;

namespace LoginCodeFirst.Validators.Category
{
    public class IndexValidator : AbstractValidator<IndexViewModel>
    {
        public IndexValidator(ICategoryServices categoryServices, IStringLocalizer<IndexViewModel> localizer)
        {
            var categories = categoryServices.GetCategory();
            foreach (var category in categories)
            {
               
                RuleFor(x => x.CategoryName).NotEqual(category.CategoryName).WithMessage(localizer["This CategoryName already exists."]);

            }
            RuleFor(x => x.CategoryName).NotNull().WithMessage(localizer["CategoryName not be empty"]);
            RuleFor(x => x.CategoryName).NotNull().WithMessage(localizer["Start with letters"]);
        }
    }
}
