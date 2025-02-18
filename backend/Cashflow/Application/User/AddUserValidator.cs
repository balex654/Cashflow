using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.User
{
    public class AddUserValidator : AbstractValidator<AddUserCommand>
    {
        public AddUserValidator()
        {
            RuleFor(input => input.Id)
                .NotNull().WithMessage("The Id must not be null")
                .NotEmpty().WithMessage("The Id must not be empty")
                .MaximumLength(450).WithMessage("The Id must be under 450 characters");

            RuleFor(input => input.FirstName)
                .NotNull().WithMessage("The FirstName must not be null")
                .NotEmpty().WithMessage("The FirstName must not be empty")
                .MaximumLength(256).WithMessage("The FirstName must be under 256 characters");

            RuleFor(input => input.LastName)
                .NotNull().WithMessage("The LastName must not be null")
                .NotEmpty().WithMessage("The LastName must not be empty")
                .MaximumLength(256).WithMessage("The LastName must be under 256 characters");

            RuleFor(input => input.Email)
                .NotNull().WithMessage("The Email must not be null")
                .NotEmpty().WithMessage("The Email must not be empty")
                .MaximumLength(256).WithMessage("The Email must be under 256 characters")
                .EmailAddress();
        }
    }
}
