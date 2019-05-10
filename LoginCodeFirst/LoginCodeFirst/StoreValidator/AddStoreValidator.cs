using System.Linq;
using FluentValidation;
using LoginCodeFirst.Models;
using Microsoft.Extensions.Localization;

namespace LoginCodeFirst.StoreValidator
{
    public class AddStoreValidator : AbstractValidator<Store>
    {
        public AddStoreValidator(CodeDataContext codeDataContext, IStringLocalizer<AddStoreValidator> localizer)
        {
            var stores = codeDataContext.Store.ToList();
            foreach (var user in stores)
            {
                RuleFor(x => x.Email).NotEqual(user.Email).WithMessage(localizer["This Email already exists."]);
            }

            RuleFor(x => x.Email).NotNull().WithMessage(localizer["Email not be empty"]);
            RuleFor(x => x.Email).EmailAddress().WithMessage(localizer["must start with a letter"]);
            RuleFor(x => x.Email).EmailAddress().WithMessage(localizer["The email must include letters and numbers"]);
            RuleFor(x => x.StoreName).NotNull().WithMessage(localizer["StoreName not be empty"]);
            RuleFor(x => x.Phone).NotNull().WithMessage(localizer["Phone not be empty"]);
        }
    }
}