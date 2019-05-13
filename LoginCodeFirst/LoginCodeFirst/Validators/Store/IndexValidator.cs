using FluentValidation;
using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels.Store;
using Microsoft.Extensions.Localization;

namespace LoginCodeFirst.Validators.Store
{
    public class IndexValidator : AbstractValidator<IndexViewModel>
    {
        public IndexValidator(IStoreServices storeServices, IStringLocalizer<IndexViewModel> localizer)
        {
            var stores = storeServices.StoreAsync();
            foreach (var store in stores)
            {
                RuleFor(x => x.Email).NotEqual(store.Email).WithMessage(localizer["This Email already exists."]);
                RuleFor(x => x.StoreName).NotEqual(store.StoreName).WithMessage(localizer["This StoreName already exists."]);

            }
            RuleFor(x => x.Email).NotNull().WithMessage(localizer["Email not be empty"]);
            RuleFor(x => x.Email).EmailAddress().WithMessage(localizer["must start with a letter"]);
            RuleFor(x => x.Email).EmailAddress().WithMessage(localizer["The email must include letters and numbers"]);
            RuleFor(x => x.Phone).NotNull().WithMessage(localizer["Phone not be empty"]);
            RuleFor(x => x.StoreName).NotNull().WithMessage(localizer["StoreName not be empty"]);
            RuleFor(x => x.State).NotNull().WithMessage(localizer["State not be empty"]);
            RuleFor(x => x.Street).NotNull().WithMessage(localizer["Street not be empty"]);
            RuleFor(x => x.City).NotNull().WithMessage(localizer["City not be empty"]);
            RuleFor(x => x.ZipCode).NotNull().WithMessage(localizer["City not be empty"]);

        }
    }
}
