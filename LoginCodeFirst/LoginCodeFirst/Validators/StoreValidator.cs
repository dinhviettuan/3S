using FluentValidation;
using LoginCodeFirst.Resources;
using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels.Store;

namespace LoginCodeFirst.Validators.Store
{
    public class StoreValidator : AbstractValidator<StoreViewModel>
    {
        public StoreValidator(ResourcesServices<StoreResources> localizer,ResourcesServices<CommonResources> commonlocalizer,IStoreServices storeServices)
        {
            RuleFor(x => x.Email).Must((Reg,c) => !storeServices.IsExistedName(Reg.Email,Reg.StoreId))
                .WithMessage((reg,c) => string.Format(commonlocalizer.GetLocalizedHtmlString("msg_AlreadyExists"),c));
                   
            
            RuleFor(x => x.Email).NotNull()
                .WithMessage(commonlocalizer.GetLocalizedHtmlString("msg_NotBeEmpty"));
            RuleFor(x => x.Email).EmailAddress()
                .WithMessage(commonlocalizer.GetLocalizedHtmlString("msg_WithALetter"));
            RuleFor(x => x.Phone).NotNull()
                .WithMessage(commonlocalizer.GetLocalizedHtmlString("msg_NotBeEmpty"));
            RuleFor(x => x.StoreName).NotNull()
                .WithMessage(commonlocalizer.GetLocalizedHtmlString("msg_NotBeEmpty"));
            RuleFor(x => x.State).NotNull()
                .WithMessage(commonlocalizer.GetLocalizedHtmlString("msg_NotBeEmpty"));
            RuleFor(x => x.Street).NotNull()
                .WithMessage(commonlocalizer.GetLocalizedHtmlString("msg_NotBeEmpty"));
            RuleFor(x => x.City).NotNull()
                .WithMessage(commonlocalizer.GetLocalizedHtmlString("msg_NotBeEmpty"));
            RuleFor(x => x.ZipCode).NotNull()
                .WithMessage(commonlocalizer.GetLocalizedHtmlString("msg_NotBeEmpty"));

        }
    }
}
