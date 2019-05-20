
using FluentValidation;
using LoginCodeFirst.Resources;
using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels.Stock;

namespace LoginCodeFirst.Validators.Stock
{
    public class StockValidator : AbstractValidator<StockViewModel>
    {

        public StockValidator(ResourcesServices<StockResources> localizer,ResourcesServices<CommonResources> commonlocalizer,IStockServices stockServices)
        {
            RuleFor(x => x.Quantity).NotNull()
                .WithMessage(commonlocalizer.GetLocalizedHtmlString("msg_NotBeEmpty"));
            RuleFor(x => x.Quantity).GreaterThanOrEqualTo(1)
                .WithMessage(localizer.GetLocalizedHtmlString("msg_QuantityGreaterThan1"));
        }
    }
}
