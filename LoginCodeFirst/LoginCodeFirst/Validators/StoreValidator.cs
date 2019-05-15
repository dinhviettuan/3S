using FluentValidation;
using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels.Store;
using Microsoft.Extensions.Localization;

namespace LoginCodeFirst.Validators.Store
{
    public class StoreValidator : AbstractValidator<StoreViewModel>
    {
        public StoreValidator(IStoreServices storeServices, IStringLocalizer<StoreViewModel> localizer)
        {
            RuleFor(x => x.Email).Must((Reg,c) => !storeServices.IsExistedName(Reg.Email,Reg.StoreId))
                .WithMessage(localizer["This Email already exists."]);
                   
            RuleFor(x => x.Email).NotNull()
                .WithMessage(localizer["Email not be empty"]);
            RuleFor(x => x.Email).EmailAddress()
                .WithMessage(localizer["must start with a letter"]);
            RuleFor(x => x.Phone).NotNull()
                .WithMessage(localizer["Phone not be empty"]);
            RuleFor(x => x.StoreName).NotNull()
                .WithMessage(localizer["StoreName not be empty"]);
            RuleFor(x => x.State).NotNull()
                .WithMessage(localizer["State not be empty"]);
            RuleFor(x => x.Street).NotNull()
                .WithMessage(localizer["Street not be empty"]);
            RuleFor(x => x.City).NotNull()
                .WithMessage(localizer["City not be empty"]);
            RuleFor(x => x.ZipCode).NotNull()
                .WithMessage(localizer["ZipCode not be empty"]);

        }
    }
}
