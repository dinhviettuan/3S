using FluentValidation;
using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels.User;
using Microsoft.Extensions.Localization;

namespace LoginCodeFirst.Validators
{
    public class IndexValidator : AbstractValidator<IndexViewModel>
    {
        public IndexValidator(IUserServices userServices, IStringLocalizer<IndexValidator> localizer)
        {
            RuleFor(x => x.Email).Must((reg,c) => !userServices.IsExistedName(reg.Email,reg.UserId))
                .WithMessage(localizer["This Email already exists."]);
            
            RuleFor(x => x.Email).NotNull().WithMessage(localizer["Email not be empty"]);
            RuleFor(x => x.Email).EmailAddress().WithMessage(localizer["Please enter a valid email!"]);
            
            RuleFor(x => x.Password).NotNull().WithMessage(localizer["Password not be empty"]);
            RuleFor(x => x.Password).MinimumLength(8).WithMessage(localizer["Password not less than 8 characters."]);
            RuleFor(x => x.Password).Matches("^(?=.*[0-9])(?=.*[a-zA-Z])([a-zA-Z0-9]+)$").WithMessage(localizer["Password must have both letters and numbers."]);
            
            RuleFor(x => x.FullName).NotNull().WithMessage(localizer["Fullname not be empty"]);
            RuleFor(x => x.Phone).NotNull().WithMessage(localizer["Phone not be empty"]);
            RuleFor(x => x.IsActive).NotNull();
        }

    }
}