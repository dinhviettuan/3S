
using FluentValidation;
using LoginCodeFirst.Resources;
using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels.Stock;

namespace LoginCodeFirst.Validators.Stock
{
    public class StockValidator : AbstractValidator<StockViewModel>
    {

        public StockValidator(ResourcesServices<StockResources> localizer,IStockServices stockServices)
        {
            RuleFor(x => x.Quantity).NotNull()
                .WithMessage(localizer.GetLocalizedHtmlString("lbl_QuantityNotBeEmpty"));
            RuleFor(x => x.Quantity).GreaterThanOrEqualTo(1)
                .WithMessage(localizer.GetLocalizedHtmlString("lbl_QuantityGreaterThan1"));
        }
    }
}
