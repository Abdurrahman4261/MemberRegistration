using FluentValidation;
using MemberRegistration.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.BusinessLayer.FluentValidation.ValidationRules
{
    
    public class ResumeValidator : AbstractValidator<Resume>
    {
        public ResumeValidator()
        {
            RuleFor(u => u.File).NotEmpty();
            RuleFor(u => u.File).NotNull();
        }
    }
}
