using FluentValidation;
using LoginCodeFirst.Resources;
using LoginCodeFirst.ViewModels;

namespace LoginCodeFirst.Validators
{
    public class StockValidator : AbstractValidator<StockViewModel>
    {

        public StockValidator(ResourcesServices<StockResources> localizer,ResourcesServices<CommonResources> commonlocalizer)
        {
            RuleFor(x => x.Quantity).NotNull()
                .WithMessage(commonlocalizer.GetLocalizedHtmlString("msg_NotEmpty"));
            
            RuleFor(x => x.Quantity).GreaterThanOrEqualTo(1)
                .WithMessage(localizer.GetLocalizedHtmlString("msg_QuantityGreaterThan1"));
        }
    }
}
