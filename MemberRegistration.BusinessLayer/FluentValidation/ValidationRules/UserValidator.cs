using FluentValidation;
using MemberRegistration.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.BusinessLayer.FluentValidation.ValidationRules
{
    public class UserValidator : AbstractValidator<Login>
    {
        public UserValidator() 
        {
            RuleFor(u=>u.Username).NotEmpty();
            RuleFor(u=>u.Username).NotNull();
            RuleFor(u=>u.Password).NotEmpty();
            RuleFor(u=>u.Password).NotNull();
        }
    }
}
