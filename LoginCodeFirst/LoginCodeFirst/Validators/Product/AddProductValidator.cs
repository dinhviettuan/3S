//using FluentValidation;
//using LoginCodeFirst.Models;
//using LoginCodeFirst.ViewModel.ProductViewModel;
//using Microsoft.Extensions.Localization;
//
//namespace LoginCodeFirst.ProductValidator
//{
//        public class AddProductValidator : AbstractValidator<AddProductValidator>
//        {
//            public AddProductValidator(CodeDataContext dataContext, IStringLocalizer<AddProductValidator> localizer)
//            {
//                RuleFor(x => x.).NotNull().WithMessage(localizer["ProductName not be empty"]);
//                RuleFor(x => x.ModelYear).NotNull().WithMessage(localizer["ModelYear not be empty"]);
//                RuleFor(x => x.ListPrice).NotNull().WithMessage(localizer["ListPrice not be empty"]);
//            }
//    }
//}