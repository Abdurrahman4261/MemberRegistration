using FluentValidation;
using MemberRegistration.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.BusinessLayer.FluentValidation.ValidationRules
{
    public class UserSignUpValidator : AbstractValidator<User>
    {
        public UserSignUpValidator() 
        {
            RuleFor(u => u.UserName).NotEmpty();
            RuleFor(u => u.UserName).NotNull();
            RuleFor(u => u.Name).NotEmpty();
            RuleFor(u => u.Name).NotNull();
            RuleFor(u => u.Surname).NotNull();
            RuleFor(u => u.Surname).NotEmpty();
            RuleFor(u => u.Email).NotNull();
            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Email).EmailAddress();
            RuleFor(u => u.Password).NotNull();
            RuleFor(u => u.Password).NotEmpty();
            RuleFor(u => u.Password).MinimumLength(7);

        }
    }
}
