//using FluentValidation;
//using LoginCodeFirst.Models;
//using LoginCodeFirst.ViewModels;
//using LoginCodeFirst.ViewModel.ProductViewModel;
//using Microsoft.Extensions.Localization;
//
//namespace LoginCodeFirst.ProductValidator
//{
//    public class EditProductValidator : AbstractValidator<EditProductViewModel>
//    {
//        public EditProductValidator(CodeDataContext dataContext, IStringLocalizer<EditProductViewModel> localizer)
//        {
//            RuleFor(x => x.ProductName).NotNull().WithMessage(localizer["ProductName not be empty"]);
//            RuleFor(x => x.ModelYear).NotNull().WithMessage(localizer["ModelYear not be empty"]);
//            RuleFor(x => x.ListPrice).NotNull().WithMessage(localizer["ListPrice not be empty"]);
//        }
//    }
//}