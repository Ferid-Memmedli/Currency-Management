using Entities.Concrete;
using FluentValidation;

namespace Business.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Email).NotNull().NotEmpty().EmailAddress().MaximumLength(250);
            RuleFor(x => x.Password).NotNull().NotEmpty().MinimumLength(6).MaximumLength(250);
        }
    }
}
