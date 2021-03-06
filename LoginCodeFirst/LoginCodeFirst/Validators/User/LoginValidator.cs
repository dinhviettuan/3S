﻿using FluentValidation;
using LoginCodeFirst.Resources;
using LoginCodeFirst.ViewModels;

namespace LoginCodeFirst.Validators.User
{
    public class LoginValidator : AbstractValidator<LoginViewModel>
    {
        public LoginValidator(ResourcesServices<CommonResources> commonlocalizer)
        {
            RuleFor(x => x.Email).NotNull().WithMessage(commonlocalizer.GetLocalizedHtmlString("msg_NotEmpty"));
            RuleFor(x => x.Password).NotNull().WithMessage(commonlocalizer.GetLocalizedHtmlString("msg_NotEmpty"));
            
            RuleFor(x => x.Email).EmailAddress().WithMessage(commonlocalizer.GetLocalizedHtmlString("msg_WithALetter"));
            RuleFor(x => x.Password).MinimumLength(8).WithMessage(commonlocalizer.GetLocalizedHtmlString("msg_8Characters"));
            
            RuleFor(x => x.Password)
                .Matches("^(?=.*[0-9])(?=.*[a-zA-Z])([a-zA-Z0-9]+)$")
                .WithMessage(commonlocalizer.GetLocalizedHtmlString("msg_LettersAndNumbers"));       
        }
    }
}