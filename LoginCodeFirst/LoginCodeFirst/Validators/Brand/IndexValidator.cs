//using FluentValidation;
//using LoginCodeFirst.Services;
//using LoginCodeFirst.ViewModels.Brand;
//using Microsoft.Extensions.Localization;

//namespace LoginCodeFirst.Validators.Brand
//{
//    public class IndexValidator : AbstractValidator<IndexViewModel>
//    {
//        public IndexValidator(IBrandServices brandServices, IStringLocalizer<IndexViewModel> localizer)
//        {
//            var brands = categoryServices.CategoriesAsync();
//            foreach (var brand in brands)
//            {

//                RuleFor(x => x.CategoryName).NotEqual(category.CategoryName).WithMessage(localizer["This CategoryName already exists."]);

//            }
//            RuleFor(x => x.CategoryName).NotNull().WithMessage(localizer["CategoryName not be empty"]);
//            RuleFor(x => x.CategoryName).NotNull().WithMessage(localizer["Start with letters"]);
//        }
//    }
//}
