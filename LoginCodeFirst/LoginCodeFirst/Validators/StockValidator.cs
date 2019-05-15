
using FluentValidation;
using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels.Stock;
using Microsoft.Extensions.Localization;

namespace LoginCodeFirst.Validators.Stock
{
    public class StockValidator : AbstractValidator<StockViewModel>
    {

        public StockValidator(IStockServices stockServices, IStringLocalizer<StockViewModel> localizer)
        {
            RuleFor(x => x.Quantity).NotNull()
                .WithMessage(localizer["Quantity not be empty"]);
            RuleFor(x => x.Quantity).GreaterThanOrEqualTo(1)
                .WithMessage(localizer["Quantity Greater than 1"]);
        }
    }
}
