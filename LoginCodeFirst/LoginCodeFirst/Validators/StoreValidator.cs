using FluentValidation;
using LoginCodeFirst.Resources;
using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels.Store;

namespace LoginCodeFirst.Validators.Store
{
    public class StoreValidator : AbstractValidator<StoreViewModel>
    {
        public StoreValidator(ResourcesServices<StoreResources> localizer,IStoreServices storeServices)
        {
            RuleFor(x => x.Email).Must((Reg,c) => !storeServices.IsExistedName(Reg.Email,Reg.StoreId))
                .WithMessage(localizer.GetLocalizedHtmlString("lbl_ThisEmailAlreadyExists"));
                   
            RuleFor(x => x.Email).NotNull()
                .WithMessage(localizer.GetLocalizedHtmlString("lbl_EmailNotBeEmpty"));
            RuleFor(x => x.Email).EmailAddress()
                .WithMessage(localizer.GetLocalizedHtmlString("lbl_MustStartWithALetter"));
            RuleFor(x => x.Phone).NotNull()
                .WithMessage(localizer.GetLocalizedHtmlString("lbl_PhoneNotBeEmpty"));
            RuleFor(x => x.StoreName).NotNull()
                .WithMessage(localizer.GetLocalizedHtmlString("lbl_StoreNameNotBeEmpty"));
            RuleFor(x => x.State).NotNull()
                .WithMessage(localizer.GetLocalizedHtmlString("lbl_StateNotBeEmpty"));
            RuleFor(x => x.Street).NotNull()
                .WithMessage(localizer.GetLocalizedHtmlString("lbl_StreetNotBeEmpty"));
            RuleFor(x => x.City).NotNull()
                .WithMessage(localizer.GetLocalizedHtmlString("lbl_CityNotBeEmpty"));
            RuleFor(x => x.ZipCode).NotNull()
                .WithMessage(localizer.GetLocalizedHtmlString("lbl_ZipCodeNotBeEmpty"));

        }
    }
}
