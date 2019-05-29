using FluentValidation;
using LoginCodeFirst.Resources;
using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels;

namespace LoginCodeFirst.Validators
{
    public class StoreValidator : AbstractValidator<StoreViewModel>
    {
        public StoreValidator(ResourcesServices<CommonResources> commonlocalizer,IStoreServices storeServices)
        {
            RuleFor(x => x.Phone).NotNull()
                .WithMessage(commonlocalizer.GetLocalizedHtmlString("msg_NotEmpty"));
            RuleFor(x => x.StoreName).NotNull()
                .WithMessage(commonlocalizer.GetLocalizedHtmlString("msg_NotEmpty"));
            RuleFor(x => x.State).NotNull()
                .WithMessage(commonlocalizer.GetLocalizedHtmlString("msg_NotEmpty"));
            RuleFor(x => x.Street).NotNull()
                .WithMessage(commonlocalizer.GetLocalizedHtmlString("msg_NotEmpty"));
            RuleFor(x => x.City).NotNull()
                .WithMessage(commonlocalizer.GetLocalizedHtmlString("msg_NotEmpty"));
            RuleFor(x => x.ZipCode).NotNull()
                .WithMessage(commonlocalizer.GetLocalizedHtmlString("msg_NotEmpty")); 
            RuleFor(x => x.Email).NotNull()
                .WithMessage(commonlocalizer.GetLocalizedHtmlString("msg_NotEmpty"));
            
            RuleFor(x => x.Email).Must((reg,c) => !storeServices.IsExistedName(reg.Email,reg.Id))
                .WithMessage((reg,c) => string.Format(commonlocalizer.GetLocalizedHtmlString("msg_AlreadyExists"),c));
                   
            RuleFor(x => x.Email).EmailAddress()
                .WithMessage(commonlocalizer.GetLocalizedHtmlString("msg_WithALetter"));
        }
    }
}
