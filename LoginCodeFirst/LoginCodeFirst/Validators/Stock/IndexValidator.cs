
using FluentValidation;
using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels.Stock;
using Microsoft.Extensions.Localization;

namespace LoginCodeFirst.Validators.Stock
{
    public class IndexValidator : AbstractValidator<IndexViewModel>
    {

        public IndexValidator(IStockServices stockServices, IStringLocalizer<IndexViewModel> localizer)
        {
            RuleFor(x => x.Quantity).NotNull().WithMessage(localizer["Quantity not be empty"]);
        }
    }
}
