
using eCommerce.Core.DTO;
using FluentValidation;

namespace eCommerce.Core.Validator
{
    public class RegisterRequestValidators: AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidators()
        {
            RuleFor(x=> x.Email).NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password cannot be empty")
                .MinimumLength(6).WithMessage("Password should be atleast 6 characters long");

            RuleFor(x => x.PersonName).NotEmpty().WithMessage("Person Name cannot be blank")
                .MinimumLength(2).WithMessage("Person name should be atleast 2 character long")
                .MaximumLength(50).WithMessage("Person name exceeding 50 chanracter")
                .Matches("^[a-zA-Z' ]*$").WithMessage("Name contains only Alphabets, single quote and space");


            RuleFor(x => x.Gender)
                .NotNull().WithMessage("Gender is required")
                .IsInEnum().WithMessage("Invalid gender option") ;

        }
    }
}
